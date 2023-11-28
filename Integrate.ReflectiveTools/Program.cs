// See https://aka.ms/new-console-template for more information

using Integrate.ReflectiveTools;

CsvModelGenerator csvModelGenerator = new CsvModelGenerator();

//csvModelGenerator.GetProperties("\"ID\";\"SKU\";\"name\";\"reference_number\";\"EAN\";\"can_be_returned\";\"producer_name\";\"category\";\"is_wire\";\"shipping\";\"package_size\";\"available\";\"logistic_height\";\"logistic_width\";\"logistic_length\";\"logistic_weight\";\"is_vendor\";\"available_in_parcel_locker\";\"default_image\";");
//csvModelGenerator.GetProperties("product_id,sku,unit,qty,manufacturer_name,manufacturer_ref_num,shipping,shipping_cost");
//csvModelGenerator.GetFuncEntries("\"ID\";\"SKU\";\"name\";\"reference_number\";\"EAN\";\"can_be_returned\";\"producer_name\";\"category\";\"is_wire\";\"shipping\";\"package_size\";\"available\";\"logistic_height\";\"logistic_width\";\"logistic_length\";\"logistic_weight\";\"is_vendor\";\"available_in_parcel_locker\";\"default_image\"");
csvModelGenerator.GetFuncEntries("product_id,sku,unit,qty,manufacturer_name,manufacturer_ref_num,shipping,shipping_cost");

Console.WriteLine("Hello, World!");
