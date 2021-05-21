static public void loadFiles()
{
    FileStream warehouse_file;
    FileStream employee_file;
    FileStream supplyDocuments_file;

    BinaryFormatter formatter = new BinaryFormatter();
    if (File.Exists("Warehouses.txt"))
    {
        warehouse_file = new FileStream("Warehouses.txt", FileMode.Open, FileAccess.Read);
        warehouseCounter = 0;
        while (warehouse_file.Position < warehouse_file.Length)
        {
            warehouses[warehouseCounter++] = (Warehouse)(formatter.Deserialize(warehouse_file));
        }
    }
    else
    {
        warehouse_file = new FileStream("Warehouses.txt", FileMode.Create);
    }
    warehouse_file.Close();


    if (File.Exists("Employees.txt"))
    {
        employee_file = new FileStream("Employees.txt", FileMode.Open, FileAccess.Read);
        employeeCounter = 0;
        while (employee_file.Position < employee_file.Length)
        {
            employees[employeeCounter++] = (Employee)formatter.Deserialize(employee_file);
        }

    }
    else
    {
        employee_file = new FileStream("Employees.txt", FileMode.Create);
    }
    employee_file.Close();


    if (File.Exists("SupplyDocuments.txt"))
    {
        supplyDocuments_file = new FileStream("SupplyDocuments.txt", FileMode.Open, FileAccess.Read);
        //int supplyDocumentsCounter = 0;
        while (supplyDocuments_file.Position < supplyDocuments_file.Length)
        {
            supplyDocuments.Add((SupplyDocument)formatter.Deserialize(supplyDocuments_file));
        }

    }
    else
    {
        supplyDocuments_file = new FileStream("SupplyDocuments.txt", FileMode.Create);
    }
    supplyDocuments_file.Close();
}
//
//Updating the whole data when any change to the data happens.
//
static public void StoreFiles()
{
    FileStream warehouse_file = new FileStream("Warehouses.txt", FileMode.Create, FileAccess.Write);
    FileStream employee_file = new FileStream("Employees.txt", FileMode.Create, FileAccess.Write);
    FileStream supplyDocuments_file = new FileStream("SupplyDocuments.txt", FileMode.Create, FileAccess.Write);

    BinaryFormatter formatter = new BinaryFormatter();

    for (int i = 0; i < warehouseCounter; i++)
    {
        formatter.Serialize(warehouse_file, warehouses[i]);
    }
    warehouse_file.Close();

    for (int i = 0; i < employeeCounter; i++)
    {
        formatter.Serialize(employee_file, employees[i]);
    }
    employee_file.Close();

    for (int i = 0; i < supplyDocuments.Count; i++)
    {
        formatter.Serialize(supplyDocuments_file, supplyDocuments[i]);
    }
    supplyDocuments_file.Close();



}