using PharmacySystem.Database;
using PharmacySystem.Logging;
using PharmacySystem.Repositories;
using PharmacySystem.Services;
using PharmacySystem.Services.Interfaces;

namespace PharmacySystem.Core
{
    /// <summary>
    /// Central application context that wires repositories and services together.
    /// </summary>
    public class PharmacyAppContext
    {
        public MongoDbContext DbContext { get; }
        public bool IsDatabaseAvailable { get; }
        public ILogger Logger { get; }
        public IValidationService ValidationService { get; }
        public MedicineService MedicineService { get; }
        public CustomerService CustomerService { get; }
        public IInventoryService InventoryService { get; }
        public SaleService SaleService { get; }

        private PharmacyAppContext(
            MongoDbContext dbContext,
            ILogger logger,
            IValidationService validationService,
            MedicineService medicineService,
            CustomerService customerService,
            IInventoryService inventoryService,
            SaleService saleService)
        {
            DbContext = dbContext;
            IsDatabaseAvailable = dbContext != null;
            Logger = logger;
            ValidationService = validationService;
            MedicineService = medicineService;
            CustomerService = customerService;
            InventoryService = inventoryService;
            SaleService = saleService;
        }

        public static PharmacyAppContext Create(MongoDbContext dbContext, ILogger logger = null)
        {
            logger = logger ?? new FileLogger();
            var validationService = new ValidationService();

            if (dbContext == null)
            {
                logger.LogWarning("Application started without database connectivity.");
                return new PharmacyAppContext(null, logger, validationService, null, null, null, null);
            }

            var medicineRepository = new MedicineRepository(dbContext);
            var customerRepository = new CustomerRepository(dbContext);
            var saleRepository = new SaleRepository(dbContext);

            var medicineService = new MedicineService(medicineRepository);
            var customerService = new CustomerService(customerRepository);
            var inventoryService = new InventoryService(medicineRepository);
            var saleService = new SaleService(saleRepository, medicineRepository, inventoryService);

            logger.LogInfo("Pharmacy application context initialized successfully.");
            return new PharmacyAppContext(
                dbContext,
                logger,
                validationService,
                medicineService,
                customerService,
                inventoryService,
                saleService);
        }
    }
}
