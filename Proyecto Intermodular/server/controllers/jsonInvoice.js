var fs = require('fs');
var contents = fs.readFileSync('invoice.json');
var jsonData = JSON.parse(contents);
for(var i=0;i<jsonData.invoice.products.length;i++){
        console.log("Producto " + i + ": " +
}