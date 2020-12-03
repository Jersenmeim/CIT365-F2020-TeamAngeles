using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    ConductingLeader = table.Column<string>(maxLength: 100, nullable: false),
                    OpeningHymn = table.Column<string>(maxLength: 100, nullable: false),
                    Invocation = table.Column<string>(maxLength: 100, nullable: false),
                    SacramentHymn = table.Column<string>(maxLength: 100, nullable: false),
                    IntermediateHymn = table.Column<string>(maxLength: 100, nullable: true),
                    ClosingHymn = table.Column<string>(maxLength: 100, nullable: false),
                    Benediction = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingId = table.Column<int>(nullable: false),
                    NameSpeaker = table.Column<string>(maxLength: 100, nullable: false),
                    Topic = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talks_Meeting_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Talks_MeetingId",
                table: "Talks",
                column: "MeetingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Talks");

            migrationBuilder.DropTable(
                name: "Meeting");
        }
    }
}
