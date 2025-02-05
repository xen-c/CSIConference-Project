using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSIConference.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capacities",
                columns: table => new
                {
                    CapacityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacities", x => x.CapacityId);
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    AttendeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.AttendeeId);
                    table.ForeignKey(
                        name: "FK_Attendees_Capacities_CapacityId",
                        column: x => x.CapacityId,
                        principalTable: "Capacities",
                        principalColumn: "CapacityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_CapacityId",
                table: "Attendees",
                column: "CapacityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Capacities");
        }
    }
}
