using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id_Area = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_Area = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description_Incidence = table.Column<int>(type: "int", nullable: true),
                    Description_Area = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id_Area);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContactType",
                columns: table => new
                {
                    Id_TypeContact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_Contact = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description_ContactType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.Id_TypeContact);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LevelIncidence",
                columns: table => new
                {
                    Id_LevelIncidence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_LevelIncidence = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description_LevelIncidence = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelIncidence", x => x.Id_LevelIncidence);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id_Rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_Rol = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description_Rol = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id_Rol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypeIncidence",
                columns: table => new
                {
                    Id_TypeIncidence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_TypeIncidence = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description_TypeIncidence = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeIncidence", x => x.Id_TypeIncidence);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id_Place = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_Place = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_AreaOrigin = table.Column<int>(type: "int", nullable: false),
                    Description_Place = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id_Place);
                    table.ForeignKey(
                        name: "FK_Place_Area_Id_AreaOrigin",
                        column: x => x.Id_AreaOrigin,
                        principalTable: "Area",
                        principalColumn: "Id_Area",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AreaUser",
                columns: table => new
                {
                    Id_AreaUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Area = table.Column<int>(type: "int", nullable: false),
                    Id_User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaUser", x => x.Id_AreaUser);
                    table.ForeignKey(
                        name: "FK_AreaUser_Area_Id_Area",
                        column: x => x.Id_Area,
                        principalTable: "Area",
                        principalColumn: "Id_Area",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CategoryContact",
                columns: table => new
                {
                    Id_CategoryContact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContactId_Contact = table.Column<int>(type: "int", nullable: true),
                    Id_Category = table.Column<int>(type: "int", nullable: false),
                    Name_CategoryContact = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryContact", x => x.Id_CategoryContact);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id_Contact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_User = table.Column<int>(type: "int", nullable: false),
                    Id_TypeCon = table.Column<int>(type: "int", nullable: false),
                    Id_CategoryContact = table.Column<int>(type: "int", nullable: false),
                    Description_Contact = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id_Contact);
                    table.ForeignKey(
                        name: "FK_Contact_CategoryContact_Id_CategoryContact",
                        column: x => x.Id_CategoryContact,
                        principalTable: "CategoryContact",
                        principalColumn: "Id_CategoryContact",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contact_ContactType_Id_TypeCon",
                        column: x => x.Id_TypeCon,
                        principalTable: "ContactType",
                        principalColumn: "Id_TypeContact",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    Id_DocumentType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_DocumentType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactId_Contact = table.Column<int>(type: "int", nullable: true),
                    Abbreviation_DocumentType = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id_DocumentType);
                    table.ForeignKey(
                        name: "FK_DocumentType_Contact_ContactId_Contact",
                        column: x => x.ContactId_Contact,
                        principalTable: "Contact",
                        principalColumn: "Id_Contact");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name_User = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname_User = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address_User = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_DocumentType = table.Column<int>(type: "int", nullable: false),
                    Id_Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id_User);
                    table.ForeignKey(
                        name: "FK_User_DocumentType_Id_DocumentType",
                        column: x => x.Id_DocumentType,
                        principalTable: "DocumentType",
                        principalColumn: "Id_DocumentType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Rol_Id_Rol",
                        column: x => x.Id_Rol,
                        principalTable: "Rol",
                        principalColumn: "Id_Rol",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetailIncidence",
                columns: table => new
                {
                    Id_DetailIncidence = table.Column<int>(type: "int", nullable: false),
                    Id_Incidence = table.Column<int>(type: "int", nullable: false),
                    Id_Peripheral = table.Column<int>(type: "int", nullable: false),
                    Id_TypeIncidence = table.Column<int>(type: "int", nullable: false),
                    Id_LevelIncidence = table.Column<int>(type: "int", nullable: false),
                    Id_State = table.Column<int>(type: "int", nullable: false),
                    Description_DetailIncidence = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailIncidence", x => x.Id_DetailIncidence);
                    table.ForeignKey(
                        name: "FK_DetailIncidence_LevelIncidence_Id_LevelIncidence",
                        column: x => x.Id_LevelIncidence,
                        principalTable: "LevelIncidence",
                        principalColumn: "Id_LevelIncidence",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailIncidence_TypeIncidence_Id_TypeIncidence",
                        column: x => x.Id_TypeIncidence,
                        principalTable: "TypeIncidence",
                        principalColumn: "Id_TypeIncidence",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Peripheral",
                columns: table => new
                {
                    Id_Peripheral = table.Column<int>(type: "int", nullable: false),
                    Name_Peripheral = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peripheral", x => x.Id_Peripheral);
                    table.ForeignKey(
                        name: "FK_Peripheral_DetailIncidence_Id_Peripheral",
                        column: x => x.Id_Peripheral,
                        principalTable: "DetailIncidence",
                        principalColumn: "Id_DetailIncidence",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id_State = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DetailIncidenceId_DetailIncidence = table.Column<int>(type: "int", nullable: true),
                    Description_State = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id_State);
                    table.ForeignKey(
                        name: "FK_State_DetailIncidence_DetailIncidenceId_DetailIncidence",
                        column: x => x.DetailIncidenceId_DetailIncidence,
                        principalTable: "DetailIncidence",
                        principalColumn: "Id_DetailIncidence");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Incidence",
                columns: table => new
                {
                    Id_Incidence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_User = table.Column<int>(type: "int", nullable: false),
                    Id_State = table.Column<int>(type: "int", nullable: false),
                    Id_Area = table.Column<int>(type: "int", nullable: false),
                    Id_Place = table.Column<int>(type: "int", nullable: false),
                    PlaceId_Place = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Description_Incidence = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Detail_Incidence = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidence", x => x.Id_Incidence);
                    table.ForeignKey(
                        name: "FK_Incidence_Area_Id_Area",
                        column: x => x.Id_Area,
                        principalTable: "Area",
                        principalColumn: "Id_Area",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidence_Place_PlaceId_Place",
                        column: x => x.PlaceId_Place,
                        principalTable: "Place",
                        principalColumn: "Id_Place");
                    table.ForeignKey(
                        name: "FK_Incidence_State_Id_State",
                        column: x => x.Id_State,
                        principalTable: "State",
                        principalColumn: "Id_State",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidence_User_Id_User",
                        column: x => x.Id_User,
                        principalTable: "User",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AreaUser_Id_Area",
                table: "AreaUser",
                column: "Id_Area");

            migrationBuilder.CreateIndex(
                name: "IX_AreaUser_Id_User",
                table: "AreaUser",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryContact_ContactId_Contact",
                table: "CategoryContact",
                column: "ContactId_Contact");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Id_CategoryContact",
                table: "Contact",
                column: "Id_CategoryContact");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Id_TypeCon",
                table: "Contact",
                column: "Id_TypeCon");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Id_User",
                table: "Contact",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_DetailIncidence_Id_LevelIncidence",
                table: "DetailIncidence",
                column: "Id_LevelIncidence");

            migrationBuilder.CreateIndex(
                name: "IX_DetailIncidence_Id_State",
                table: "DetailIncidence",
                column: "Id_State");

            migrationBuilder.CreateIndex(
                name: "IX_DetailIncidence_Id_TypeIncidence",
                table: "DetailIncidence",
                column: "Id_TypeIncidence");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentType_ContactId_Contact",
                table: "DocumentType",
                column: "ContactId_Contact");

            migrationBuilder.CreateIndex(
                name: "IX_Incidence_Id_Area",
                table: "Incidence",
                column: "Id_Area");

            migrationBuilder.CreateIndex(
                name: "IX_Incidence_Id_State",
                table: "Incidence",
                column: "Id_State");

            migrationBuilder.CreateIndex(
                name: "IX_Incidence_Id_User",
                table: "Incidence",
                column: "Id_User");

            migrationBuilder.CreateIndex(
                name: "IX_Incidence_PlaceId_Place",
                table: "Incidence",
                column: "PlaceId_Place");

            migrationBuilder.CreateIndex(
                name: "IX_Place_Id_AreaOrigin",
                table: "Place",
                column: "Id_AreaOrigin");

            migrationBuilder.CreateIndex(
                name: "IX_State_DetailIncidenceId_DetailIncidence",
                table: "State",
                column: "DetailIncidenceId_DetailIncidence");

            migrationBuilder.CreateIndex(
                name: "IX_User_Id_DocumentType",
                table: "User",
                column: "Id_DocumentType");

            migrationBuilder.CreateIndex(
                name: "IX_User_Id_Rol",
                table: "User",
                column: "Id_Rol");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaUser_User_Id_User",
                table: "AreaUser",
                column: "Id_User",
                principalTable: "User",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryContact_Contact_ContactId_Contact",
                table: "CategoryContact",
                column: "ContactId_Contact",
                principalTable: "Contact",
                principalColumn: "Id_Contact");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_User_Id_User",
                table: "Contact",
                column: "Id_User",
                principalTable: "User",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailIncidence_Incidence_Id_DetailIncidence",
                table: "DetailIncidence",
                column: "Id_DetailIncidence",
                principalTable: "Incidence",
                principalColumn: "Id_Incidence",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailIncidence_State_Id_State",
                table: "DetailIncidence",
                column: "Id_State",
                principalTable: "State",
                principalColumn: "Id_State",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidence_Area_Id_Area",
                table: "Incidence");

            migrationBuilder.DropForeignKey(
                name: "FK_Place_Area_Id_AreaOrigin",
                table: "Place");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_Id_User",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidence_User_Id_User",
                table: "Incidence");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryContact_Contact_ContactId_Contact",
                table: "CategoryContact");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailIncidence_Incidence_Id_DetailIncidence",
                table: "DetailIncidence");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailIncidence_LevelIncidence_Id_LevelIncidence",
                table: "DetailIncidence");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailIncidence_State_Id_State",
                table: "DetailIncidence");

            migrationBuilder.DropTable(
                name: "AreaUser");

            migrationBuilder.DropTable(
                name: "Peripheral");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "CategoryContact");

            migrationBuilder.DropTable(
                name: "ContactType");

            migrationBuilder.DropTable(
                name: "Incidence");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "LevelIncidence");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "DetailIncidence");

            migrationBuilder.DropTable(
                name: "TypeIncidence");
        }
    }
}
