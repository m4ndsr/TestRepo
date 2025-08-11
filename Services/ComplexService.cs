namespace MyServiceNamespace
{
    public class ComplexService
    {
        public bool ValidateOptions(
            bool isFeatureEnabled,
            bool isLoggingEnabled,
            int timeoutInSeconds,
            int maxRetries,
            string dataCollectionMode,
            bool isStrictValidation)
        {
            bool isValid = true;

            if (isStrictValidation && timeoutInSeconds < 10)
            {
                Console.WriteLine("Error: Timeout must be at least 10 seconds in strict validation mode.");
                isValid = false;
            }

            if (maxRetries < 0)
            {
                Console.WriteLine("Error: Maximum retries cannot be negative.");
                isValid = false;
            }

            if (!isFeatureEnabled && isLoggingEnabled)
            {
                Console.WriteLine("Warning: Logging is enabled but the main feature is not. This may result in empty logs.");
            }

            if (string.IsNullOrEmpty(dataCollectionMode))
            {
                Console.WriteLine("Error: Data collection mode must be specified.");
                isValid = false;
            }

            if (dataCollectionMode.ToLower() != "full" && dataCollectionMode.ToLower() != "partial")
            {
                Console.WriteLine("Error: Invalid data collection mode specified.");
                isValid = false;
            }

            return isValid;
        }

        public List<int> ProcessComplexData(
            string serviceMode,
            int[] inputData,
            int threshold,
            bool enableCaching,
            int maxItemsToProcess,
            int customModifier)
        {
            var results = new List<int>();

            switch (serviceMode.ToLower())
            {
                case "fast":
                    Console.WriteLine("Operating in fast mode. Skipping some checks.");
                    if (enableCaching)
                    {
                        Console.WriteLine("Caching enabled. Checking cache...");
                    }
                    else
                    {
                        Console.WriteLine("Caching is disabled.");
                    }
                    break;

                case "safe":
                    Console.WriteLine("Operating in safe mode. Performing full validation.");
                    if (enableCaching)
                    {
                        Console.WriteLine("Caching enabled.");
                    }
                    else
                    {
                        Console.WriteLine("Caching is disabled.");
                    }
                    break;

                case "debug":
                    Console.WriteLine("Operating in debug mode. Verbose logging enabled.");
                    break;

                default:
                    Console.WriteLine("Warning: Invalid service mode. Defaulting to 'safe'.");
                    serviceMode = "safe";
                    break;
            }

            int itemsProcessed = 0;
            for (int i = 0; i < inputData.Length && itemsProcessed < maxItemsToProcess; i++)
            {
                int currentNumber = inputData[i];

                if (currentNumber > threshold)
                {
                    if (serviceMode.ToLower() == "debug" && currentNumber % 2 == 0)
                    {
                        Console.WriteLine($"Debug: Processing even number {currentNumber} > threshold {threshold}.");
                        results.Add(currentNumber + customModifier);
                    }
                    else if (serviceMode.ToLower() == "safe")
                    {
                        if (currentNumber < int.MaxValue / 2)
                        {
                            results.Add(currentNumber * 2);
                        }
                        else
                        {
                            Console.WriteLine($"Warning: Skipping large number {currentNumber} in safe mode.");
                        }
                    }
                    else
                    {
                        results.Add(currentNumber + customModifier);
                    }

                    itemsProcessed++;
                }
                else
                {
                    Console.WriteLine($"Info: Number {currentNumber} is below threshold {threshold}. Skipping.");
                }

                if (itemsProcessed % 10 == 0)
                {
                    Console.WriteLine($"Progress: Processed {itemsProcessed} items so far.");
                }
            }

            Console.WriteLine($"Processing complete. {results.Count} items were added to the results list.");
            return results;
        }
    }
}
