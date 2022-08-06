using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlkemyChallenge.AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    History = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UsersId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharactersMovies",
                columns: table => new
                {
                    CharactersMoviesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CharactersCharacterId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharactersMovies", x => x.CharactersMoviesId);
                    table.ForeignKey(
                        name: "FK_CharactersMovies_Characters_CharactersCharacterId",
                        column: x => x.CharactersCharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharactersMovies_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterId", "Age", "History", "Img", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, 37, "Un joven que vive en la ciudad de Agrabah", "https://cdn.s7.shopdisney.eu/is/image/ShopDisneyEMEA/33631_aladdin_character_sq_l?$characterImageSizeDesktop1x$&fit=constrain", "Alladin", 50f },
                    { 2, 11, "Una niña que sueña despierta y ama la lectura", "https://cdn.s7.shopdisney.eu/is/image/ShopDisneyEMEA/33631_alice_character_sq_l?$characterImageSizeDesktop1x$&fit=constrain", "Alicia", 30f },
                    { 3, 20, "Una niña que tiene el poder de convertir lo que toca en hielo.", "https://cdn.s7.shopdisney.eu/is/image/ShopDisneyEMEA/33631_anna_character_sq_l?$characterImageSizeDesktop1x$&fit=constrain", "Anna", 45f }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Img", "Name" },
                values: new object[,]
                {
                    { 1, "img1", "Terror" },
                    { 2, "img1", "Comedy" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Date", "GenreId", "Img", "Score", "Title" },
                values: new object[] { new Guid("002a442c-c613-4b64-a788-185cfc37c0b2"), new DateTime(1992, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://i.ebayimg.com/images/g/SQMAAOSwxxdZZHT0/s-l1600.jpg", 5, "Alladin" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Date", "GenreId", "Img", "Score", "Title" },
                values: new object[] { new Guid("6042d900-5f13-476a-886c-bd3f3ef9105f"), new DateTime(1951, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://i.etsystatic.com/16952472/r/il/ae1e62/1582515765/il_fullxfull.1582515765_5zfo.jpg", 4, "Alice in the Wonderland" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Date", "GenreId", "Img", "Score", "Title" },
                values: new object[] { new Guid("3520916a-6abd-46f3-d6fb-08d9bc5e7c19"), new DateTime(2013, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://m.media-amazon.com/images/I/710gvMtoFcL._AC_SY679_.jpg", 2, "Frozen" });

            migrationBuilder.InsertData(
                table: "CharactersMovies",
                columns: new[] { "CharactersMoviesId", "CharactersCharacterId", "MoviesId" },
                values: new object[] { new Guid("9194dec1-8906-46a2-a684-57cef2d8e657"), 1, new Guid("002a442c-c613-4b64-a788-185cfc37c0b2") });

            migrationBuilder.InsertData(
                table: "CharactersMovies",
                columns: new[] { "CharactersMoviesId", "CharactersCharacterId", "MoviesId" },
                values: new object[] { new Guid("8ff99117-0e0b-4e27-bc1d-057397ec016d"), 2, new Guid("6042d900-5f13-476a-886c-bd3f3ef9105f") });

            migrationBuilder.InsertData(
                table: "CharactersMovies",
                columns: new[] { "CharactersMoviesId", "CharactersCharacterId", "MoviesId" },
                values: new object[] { new Guid("0cb7ea92-c7a0-47eb-ad39-14824fcaae91"), 3, new Guid("3520916a-6abd-46f3-d6fb-08d9bc5e7c19") });

            migrationBuilder.CreateIndex(
                name: "IX_CharactersMovies_CharactersCharacterId",
                table: "CharactersMovies",
                column: "CharactersCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharactersMovies_MoviesId",
                table: "CharactersMovies",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharactersMovies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
