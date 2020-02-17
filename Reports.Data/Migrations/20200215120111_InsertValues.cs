using Microsoft.EntityFrameworkCore.Migrations;

namespace Reports.Data.Migrations
{
    public partial class InsertValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("INSERT INTO Cities (Name) Values ('Kiev')");
            migrationBuilder
                .Sql("INSERT INTO Cities (Name) Values ('Dnepr')");
            migrationBuilder
                .Sql("INSERT INTO Cities (Name) Values ('Kharkov')");

            migrationBuilder
                .Sql("INSERT INTO Trips (ArrivalCityId, DepartureCityId, Date) Values ((SELECT Id FROM Cities WHERE Name = 'Kiev'),(SELECT Id FROM Cities WHERE Name = 'Dnepr'), CONVERT(date, '01-01-2020', 105))");
            migrationBuilder
                .Sql("INSERT INTO Trips (ArrivalCityId, DepartureCityId, Date) Values ((SELECT Id FROM Cities WHERE Name = 'Kiev'),(SELECT Id FROM Cities WHERE Name = 'Kharkov'), CONVERT(date, '01-01-2020', 105))");
            migrationBuilder
                .Sql("INSERT INTO Trips (ArrivalCityId, DepartureCityId, Date) Values ((SELECT Id FROM Cities WHERE Name = 'Dnepr'),(SELECT Id FROM Cities WHERE Name = 'Kiev'), CONVERT(date, '02-01-2020', 105))");
            migrationBuilder
                .Sql("INSERT INTO Trips (ArrivalCityId, DepartureCityId, Date) Values ((SELECT Id FROM Cities WHERE Name = 'Dnepr'),(SELECT Id FROM Cities WHERE Name = 'Kharkov'), CONVERT(date, '02-01-2020', 105))");
            migrationBuilder
                .Sql("INSERT INTO Trips (ArrivalCityId, DepartureCityId, Date) Values ((SELECT Id FROM Cities WHERE Name = 'Kharkov'),(SELECT Id FROM Cities WHERE Name = 'Kiev'), CONVERT(date, '03-01-2020', 105))");
            migrationBuilder
                .Sql("INSERT INTO Trips (ArrivalCityId, DepartureCityId, Date) Values ((SELECT Id FROM Cities WHERE Name = 'Kharkov'),(SELECT Id FROM Cities WHERE Name = 'Dnepr'), CONVERT(date, '03-01-2020', 105))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql("DELETE FROM Cities");

            migrationBuilder
                .Sql("DELETE FROM Trips");
        }
    }
}
