using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class everythingok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 29, 16, 40, 51, 391, DateTimeKind.Local).AddTicks(173),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 29, 16, 37, 33, 602, DateTimeKind.Local).AddTicks(3681));

            migrationBuilder.InsertData(
                table: "AdditionalServices",
                columns: new[] { "Id", "DailyPrice", "Name" },
                values: new object[,]
                {
                    { 1, 200m, "Baby Seat" },
                    { 2, 300m, "Scooter" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "BMW" },
                    { 2, "Mercedes" }
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Red" },
                    { 2, "Blue" }
                });

            migrationBuilder.InsertData(
                table: "CorporateCustomers",
                columns: new[] { "Id", "CompanyName", "CustomerId", "TaxNo" },
                values: new object[] { 1, "Ahmet Çetinkaya", 2, "54154512" });

            migrationBuilder.InsertData(
                table: "FindeksCreditRates",
                columns: new[] { "Id", "CustomerId", "Score" },
                values: new object[,]
                {
                    { 1, 1, (short)1000 },
                    { 2, 2, (short)1900 }
                });

            migrationBuilder.InsertData(
                table: "Fuels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Diesel" },
                    { 2, "Electric" }
                });

            migrationBuilder.InsertData(
                table: "IndividualCustomers",
                columns: new[] { "Id", "CustomerId", "FirstName", "LastName", "NationalIdentity" },
                values: new object[] { 1, 1, "Ahmet", "Çetinkaya", "123123123123" });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedDate", "CustomerId", "No", "RentalEndDate", "RentalPrice", "RentalStartDate", "TotalRentalDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), 1, "123123", new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Local), 1000m, new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), (short)2 },
                    { 2, new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), 1, "123123", new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Local), 2000m, new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), (short)2 }
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "RentalBranches",
                columns: new[] { "Id", "City" },
                values: new object[,]
                {
                    { 1, 59 },
                    { 2, 34 }
                });

            migrationBuilder.InsertData(
                table: "Transmissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Manuel" },
                    { 2, "Automatic" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "DailyPrice", "FuelId", "ImageUrl", "Name", "TransmissionId" },
                values: new object[] { 1, 1, 1000m, 1, "", "418i", 2 });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "DailyPrice", "FuelId", "ImageUrl", "Name", "TransmissionId" },
                values: new object[] { 2, 2, 600m, 2, "", "CLA 180D", 1 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "State", "ColorId", "Kilometer", "MinFindeksCreditRate", "ModelId", "ModelYear", "Plate", "RentalBranchId" },
                values: new object[] { 1, 1, 1, 1000, (short)500, 1, (short)2018, "07ABC07", 1 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "State", "ColorId", "Kilometer", "MinFindeksCreditRate", "ModelId", "ModelYear", "Plate", "RentalBranchId" },
                values: new object[] { 2, 2, 2, 1000, (short)1100, 2, (short)2018, "15ABC15", 2 });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "CustomerId", "RentEndDate", "RentEndKilometer", "RentStartDate", "RentStartKilometer", "ReturnDate" },
                values: new object[] { 1, 2, 1, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Local), 1200, new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), 1000, null });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "CustomerId", "RentEndDate", "RentEndKilometer", "RentStartDate", "RentStartKilometer", "ReturnDate" },
                values: new object[] { 2, 1, 2, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Local), 1200, new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Local), 1000, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdditionalServices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AdditionalServices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CorporateCustomers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FindeksCreditRates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FindeksCreditRates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IndividualCustomers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RentalBranches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentalBranches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fuels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fuels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transmissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transmissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 29, 16, 37, 33, 602, DateTimeKind.Local).AddTicks(3681),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 29, 16, 40, 51, 391, DateTimeKind.Local).AddTicks(173));
        }
    }
}
