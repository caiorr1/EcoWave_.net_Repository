using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoWave.Migrations
{
    /// <inheritdoc />
    public partial class oracledb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    localizacao_id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome_localizacao = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    descricao = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.localizacao_id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeUsuario = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    SenhaHash = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    FotoPerfil = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Amigos",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AmigoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataAmizade = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amigos", x => new { x.UsuarioId, x.AmigoId });
                    table.ForeignKey(
                        name: "FK_Amigos_Usuarios_AmigoId",
                        column: x => x.AmigoId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Amigos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Configuracoes",
                columns: table => new
                {
                    configuracao_id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    usuario_id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    nome_configuracao = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    valor_configuracao = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracoes", x => x.configuracao_id);
                    table.ForeignKey(
                        name: "FK_Configuracoes_Usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensReciclados",
                columns: table => new
                {
                    item_id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    usuario_id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    tipo_item = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    data_coleta = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    localizacao = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    quantidade = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensReciclados", x => x.item_id);
                    table.ForeignKey(
                        name: "FK_ItensReciclados_Usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recompensas",
                columns: table => new
                {
                    recompensa_id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    usuario_id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    pontos = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    tipo_recompensa = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    data_resgate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recompensas", x => x.recompensa_id);
                    table.ForeignKey(
                        name: "FK_Recompensas_Usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReconhecimentoItens",
                columns: table => new
                {
                    reconhecimento_id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    usuario_id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    url_imagem = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: false),
                    tipo_item = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    data_reconhecimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    localizacao = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReconhecimentoItens", x => x.reconhecimento_id);
                    table.ForeignKey(
                        name: "FK_ReconhecimentoItens_Usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amigos_AmigoId",
                table: "Amigos",
                column: "AmigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuracoes_usuario_id",
                table: "Configuracoes",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_ItensReciclados_usuario_id",
                table: "ItensReciclados",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Recompensas_usuario_id",
                table: "Recompensas",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReconhecimentoItens_usuario_id",
                table: "ReconhecimentoItens",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amigos");

            migrationBuilder.DropTable(
                name: "Configuracoes");

            migrationBuilder.DropTable(
                name: "ItensReciclados");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropTable(
                name: "Recompensas");

            migrationBuilder.DropTable(
                name: "ReconhecimentoItens");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
