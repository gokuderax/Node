'use strict';
const Invoice = require('../models/invoice');
function getInvoices(req,res){
		Invoice.find({}, (err, invoices) => {
		if(err) return res.status(500).send({message: 'Error en petición ${err}' });
		if(!invoices) return res.status(404).send({message: 'No se han encontrado facturas'});
		res.status(200).send({invoices});
		res.end();
});
}
function getInvoice(req, res) {
    let invoiceId = req.params.invoiceId;
    Invoice.findById(invoiceId, (err, invoices) => {
        if(err) return res.status(500).send({message: `Error en petición ${err}` });
        if(!invoices) return res.status(404).send({message: 'No se han encontrado facturas'});
        res.status(200).send({invoices});
        res.end();
    });
}
function saveInvoice(req,res){

		var jsonInvoice = req.body.invoice;
		let invoice = new Invoice();
        invoice.id = jsonInvoice.id;
        invoice.id_client = jsonInvoice.id_client;
        invoice.id_shop = jsonInvoice.id_shop;
        invoice.id_salesperson = jsonInvoice.id_salesperson;
        invoice.taxes = jsonInvoice.taxes;
        invoice.base_total = jsonInvoice.base_total;
        invoice.base_advanced = jsonInvoice.base_advanced;
        invoice.observations = jsonInvoice.observations;
        invoice.products= jsonInvoice.products;
        console.log(invoice);
        var arrayProductos = invoice.products;

        for(var i=0;i<arrayProductos.length;i++){

                console.log("Producto " + i + " ID: " + arrayProductos[i].id + " Quantity: " + arrayProductos[i].quantity);

        }
		//1)Recibimos un JSON -> Hay que parsearlo al objeto invoice
		//2)Guardar el objeto invoice en mongo
		//3)Iterar por cada uno de los elementos del array Products y restar las cantidades de cada producto (porque el id_shop lo tenemos)
		invoice.save((err, invoiceStored) => {
		if(err)
		 res.status(500).send({message:`Error al guardar factura ${err}`});
		else
		res.status(200).send({invoice: invoiceStored});

	res.end();
	});
}
function updateInvoice(req,res){
		let invoiceId = req.params.invoiceId;
		let update = req.body;
		Invoice.findByIdAndUpdate(invoiceId,update, (err, productUpdated)=>{
			if(err) res.status(500).send({message:`Error al actualizar factura ${err}`});
		res.status(200).send({invoice: invoiceUpdated});
		res.end();
		});
}
function deleteInvoice(req,res){
		let invoiceId = req.params.invoiceId;
		Invoice.findByIdAndRemove(invoiceId, (err, productDelete)=>{
			 if(err) res.status(500).send({message:`No ${invoiceId}`});
			 if(err) res.status(500).send({message:`Error al eliminar la factura con id ${invoiceId}`});
			 	res.status(200).send({message: `la factura ${invoiceId} ha sido eliminada`});
		});
		
}

module.exports = {getInvoices,getInvoice,saveInvoice,updateInvoice,deleteInvoice};