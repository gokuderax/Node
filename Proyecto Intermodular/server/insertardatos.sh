!#/bin/bash
for i in `seq 1 100`;

do
	curl --data "name=n$i&picture=picture$i&price=$i&category=computers&description=descripcion$i" localhost:3000/api/product
echo $i;
done