using Ex1;

UserService userService = new();
DeviceService deviceService = new();
RentalService rentalService = new();
ReportService reportService = new();

while (true)
{
    Console.WriteLine("1 Add user");
    Console.WriteLine("2 Add device");
    Console.WriteLine("3 List of Devices");
    Console.WriteLine("4 Available Devices");
    Console.WriteLine("5 Rent device");
    Console.WriteLine("6 Return device");
    Console.WriteLine("7 Mark the device unavailable");
    Console.WriteLine("8 Active rentals");
    Console.WriteLine("9 Overdue rentals");
    Console.WriteLine("10 REPORT");
    

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine("1 Student");
            Console.WriteLine("2 Employee");

            var type = Console.ReadLine();

            Console.Write("First name: ");
            var firstName = Console.ReadLine();

            Console.Write("Last name: ");
            var lastName = Console.ReadLine();

            if (type == "1")
                userService.AddUser(new Student(firstName, lastName));

            else
                userService.AddUser(new Employee(firstName, lastName));

            Console.WriteLine("User added!"); 
            break;

        case "2":
            Console.WriteLine("1 Laptop");
            Console.WriteLine("2 Camera");
            Console.WriteLine("3 Projector");

            var eqType = Console.ReadLine();

            Console.Write("Name: ");
            var name = Console.ReadLine();

            if (eqType == "1")
            {
                Console.Write("RAM: ");
                int ram = int.Parse(Console.ReadLine());

                Console.Write("CPU: ");
                string cpu = Console.ReadLine();

                deviceService.AddDevice(
                    new Laptop(name, cpu, ram));
            }

            else if (eqType == "2")
            {
                Console.Write("Resolution: ");
                int resolution = int.Parse(Console.ReadLine());

                deviceService.AddDevice(
                    new Camera(name, resolution, true));
            }

            else
            {
                Console.Write("Lumens: ");
                int lumens = int.Parse(Console.ReadLine());

                deviceService.AddDevice(
                    new Projector(name, lumens, true));
            }

            Console.WriteLine("Equipment added!");
            break;
            
        case "3":
            foreach (var device in deviceService.GetAllDevices())
            {
                Console.WriteLine($"{device.id} {device.Name} Available: {device.isAvailable}");
            }

            break;
        
        case "4":
            foreach (var device in deviceService.GetAvailableDevices())
                Console.WriteLine($"{device.id} {device.Name}");
            break;
        
        case "5":
            Console.WriteLine("Users:");

            foreach (var user in userService.GetAllUsers())
                Console.WriteLine($"{user.Id} {user.FirstName}");
            
            Console.WriteLine("Available devices:");

            foreach (var device in deviceService.GetAvailableDevices())
                Console.WriteLine($"{device.id} {device.Name}");
            Console.Write("User id: ");
            int userId = int.Parse(Console.ReadLine());

            Console.Write("Equipment id: ");
            int eqId = int.Parse(Console.ReadLine());

            Console.Write("Days: ");
            int days = int.Parse(Console.ReadLine());

            var userObj = userService.GetUserById(userId);
            var dObj = deviceService.GetDeviceById(eqId);

            if (userObj == null || dObj == null)
            {
                Console.WriteLine("Wrong data!");
                break;
            }

            bool success =
                rentalService.RentDevice(userObj, dObj, days);

            if (success)
                Console.WriteLine("Rental successful!");

            else
                Console.WriteLine("Rental failed!");

            break;
        
        case "6":
            foreach (var rental in rentalService.GetActiveRentals())
            {
                Console.WriteLine($"{rental.Device.id} {rental.Device.Name}");
            }

            Console.Write("Device id: ");
            int id = int.Parse(Console.ReadLine());

            var rentalObj = rentalService.GetRentalByDeviceId(id);

            if (rentalObj == null)
            {
                Console.WriteLine("Not found");
                break;
            }

            var penalty = rentalService.ReturnDevice(rentalObj);

            Console.WriteLine($"Returned. Penalty: {penalty}");

            break;
        case "7":
            Console.Write("Device id: ");

            int selDId = int.Parse(Console.ReadLine());

            deviceService.MarkUnavailable(selDId);

            Console.WriteLine("Marked unavailable");

            break;
        case "8":

            Console.Write("User id: ");

            int selUID = int.Parse(Console.ReadLine());

            var selUser = userService.GetUserById(selUID);

            var rentals = rentalService.GetUserActiveRentals(selUser);

            foreach (var r in rentals)
            {
                Console.WriteLine($"{r.Device.Name}");
            }

            break;
        case "9":

            foreach (var rental in rentalService.GetOverdueRentals())
            {
                Console.WriteLine($"{rental.Device.Name}");
            }

            break;
        case "10":

            reportService.PrintReport(
                deviceService.GetAllDevices(),
                rentalService.GetAllRentals());

            break;
    }
    
}

