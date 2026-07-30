using Newtonsoft.Json;
using System.Text;

var currentDirectory = Directory.GetCurrentDirectory();

var storesDirectory = Path.Combine(
    currentDirectory,
    "stores"
);

var salesTotalDir = Path.Combine(
    currentDirectory,
    "salesTotalDir"
);

Directory.CreateDirectory(salesTotalDir);

var salesFiles = FindFiles(storesDirectory);

var salesTotal = CalculateSalesTotal(salesFiles);

var summaryPath = Path.Combine(
    salesTotalDir,
    "sales-summary.txt"
);

GenerateSalesSummaryReport(
    salesFiles,
    salesTotal,
    summaryPath
);

Console.WriteLine(
    $"Sales summary created: {summaryPath}"
);

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new();

    var foundFiles = Directory.EnumerateFiles(
        folderName,
        "*",
        SearchOption.AllDirectories
    );

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);

        if (
            extension.Equals(
                ".json",
                StringComparison.OrdinalIgnoreCase
            )
        )
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

double CalculateSalesTotal(
    IEnumerable<string> salesFiles
)
{
    double salesTotal = 0;

    foreach (var file in salesFiles)
    {
        string salesJson = File.ReadAllText(file);

        SalesData? data =
            JsonConvert.DeserializeObject<SalesData?>(
                salesJson
            );

        salesTotal += data?.Total ?? 0;
    }

    return salesTotal;
}

void GenerateSalesSummaryReport(
    IEnumerable<string> salesFiles,
    double salesTotal,
    string outputFile
)
{
    StringBuilder report = new();

    report.AppendLine("Sales Summary");
    report.AppendLine("----------------------------");
    report.AppendLine(
        $"Total Sales: {salesTotal:C}"
    );
    report.AppendLine();
    report.AppendLine("Details:");

    foreach (var file in salesFiles)
    {
        string salesJson = File.ReadAllText(file);

        SalesData? data =
            JsonConvert.DeserializeObject<SalesData?>(
                salesJson
            );

        double total = data?.Total ?? 0;

        string fileName = Path.GetRelativePath(
            Directory.GetCurrentDirectory(),
            file
        );

        report.AppendLine(
            $"  {fileName}: {total:C}"
        );
    }

    File.WriteAllText(
        outputFile,
        report.ToString()
    );
}

record SalesData(double Total);