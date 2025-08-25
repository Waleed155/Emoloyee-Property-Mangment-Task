using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emoloyee_Property_Mangment_Task.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProperty_Employees_EmployeeId",
                table: "EmployeeProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProperty_Property_PropertyId",
                table: "EmployeeProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_Option_Property_PropertyId",
                table: "Option");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Property",
                table: "Property");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Option",
                table: "Option");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeProperty",
                table: "EmployeeProperty");

            migrationBuilder.RenameTable(
                name: "Property",
                newName: "properties");

            migrationBuilder.RenameTable(
                name: "Option",
                newName: "Options");

            migrationBuilder.RenameTable(
                name: "EmployeeProperty",
                newName: "EmployeeProperties");

            migrationBuilder.RenameIndex(
                name: "IX_Option_PropertyId",
                table: "Options",
                newName: "IX_Options_PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeProperty_PropertyId",
                table: "EmployeeProperties",
                newName: "IX_EmployeeProperties_PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeProperty_EmployeeId",
                table: "EmployeeProperties",
                newName: "IX_EmployeeProperties_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_properties",
                table: "properties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeProperties",
                table: "EmployeeProperties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProperties_Employees_EmployeeId",
                table: "EmployeeProperties",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProperties_properties_PropertyId",
                table: "EmployeeProperties",
                column: "PropertyId",
                principalTable: "properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_properties_PropertyId",
                table: "Options",
                column: "PropertyId",
                principalTable: "properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProperties_Employees_EmployeeId",
                table: "EmployeeProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProperties_properties_PropertyId",
                table: "EmployeeProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_properties_PropertyId",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_properties",
                table: "properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeProperties",
                table: "EmployeeProperties");

            migrationBuilder.RenameTable(
                name: "properties",
                newName: "Property");

            migrationBuilder.RenameTable(
                name: "Options",
                newName: "Option");

            migrationBuilder.RenameTable(
                name: "EmployeeProperties",
                newName: "EmployeeProperty");

            migrationBuilder.RenameIndex(
                name: "IX_Options_PropertyId",
                table: "Option",
                newName: "IX_Option_PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeProperties_PropertyId",
                table: "EmployeeProperty",
                newName: "IX_EmployeeProperty_PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeProperties_EmployeeId",
                table: "EmployeeProperty",
                newName: "IX_EmployeeProperty_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Property",
                table: "Property",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Option",
                table: "Option",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeProperty",
                table: "EmployeeProperty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProperty_Employees_EmployeeId",
                table: "EmployeeProperty",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProperty_Property_PropertyId",
                table: "EmployeeProperty",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Option_Property_PropertyId",
                table: "Option",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
