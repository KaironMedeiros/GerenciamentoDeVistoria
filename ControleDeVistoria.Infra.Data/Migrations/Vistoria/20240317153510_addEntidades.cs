using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeVistoria.Infra.Data.Migrations.Vistoria
{
    /// <inheritdoc />
    public partial class addEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imoveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoImovel = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imoveis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vistoriadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vistoriadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ImovelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locatarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImovelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locatarios_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vistorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataVistoria = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedidorAgua = table.Column<int>(type: "int", nullable: false),
                    MedidorEnergia = table.Column<int>(type: "int", nullable: false),
                    TipoVistoria = table.Column<int>(type: "int", nullable: false),
                    VistoriadorId = table.Column<int>(type: "int", nullable: false),
                    ImovelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vistorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vistorias_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vistorias_Vistoriadores_VistoriadorId",
                        column: x => x.VistoriadorId,
                        principalTable: "Vistoriadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ambientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SituacaoEletrica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReparoEletrica = table.Column<bool>(type: "bit", nullable: false),
                    ObsEletrica = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SituacaoEsquadrias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReparoEsquadrias = table.Column<bool>(type: "bit", nullable: false),
                    ObsEsquadrias = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SituacaoHidraulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReparoHidraulica = table.Column<bool>(type: "bit", nullable: false),
                    ObsHidraulica = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SituacaoPintura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReparoPintura = table.Column<bool>(type: "bit", nullable: false),
                    ObsPintura = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SituacaoPiso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReparoPiso = table.Column<bool>(type: "bit", nullable: false),
                    ObsPiso = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SituacaoTeto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReparoTeto = table.Column<bool>(type: "bit", nullable: false),
                    ObsTeto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VistoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ambientes_Vistorias_VistoriaId",
                        column: x => x.VistoriaId,
                        principalTable: "Vistorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ambientes_VistoriaId",
                table: "Ambientes",
                column: "VistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ImovelId",
                table: "Enderecos",
                column: "ImovelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locatarios_ImovelId",
                table: "Locatarios",
                column: "ImovelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vistorias_ImovelId",
                table: "Vistorias",
                column: "ImovelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vistorias_VistoriadorId",
                table: "Vistorias",
                column: "VistoriadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ambientes");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Locatarios");

            migrationBuilder.DropTable(
                name: "Vistorias");

            migrationBuilder.DropTable(
                name: "Imoveis");

            migrationBuilder.DropTable(
                name: "Vistoriadores");
        }
    }
}
