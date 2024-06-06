using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoWave.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configuracoes_Usuarios_usuario_id",
                table: "Configuracoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensReciclados_Usuarios_usuario_id",
                table: "ItensReciclados");

            migrationBuilder.DropForeignKey(
                name: "FK_Recompensas_Usuarios_usuario_id",
                table: "Recompensas");

            migrationBuilder.DropForeignKey(
                name: "FK_ReconhecimentoItens_Usuarios_usuario_id",
                table: "ReconhecimentoItens");

            migrationBuilder.RenameColumn(
                name: "localizacao",
                table: "ReconhecimentoItens",
                newName: "Localizacao");

            migrationBuilder.RenameColumn(
                name: "usuario_id",
                table: "ReconhecimentoItens",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "url_imagem",
                table: "ReconhecimentoItens",
                newName: "UrlImagem");

            migrationBuilder.RenameColumn(
                name: "tipo_item",
                table: "ReconhecimentoItens",
                newName: "TipoItem");

            migrationBuilder.RenameColumn(
                name: "data_reconhecimento",
                table: "ReconhecimentoItens",
                newName: "DataReconhecimento");

            migrationBuilder.RenameColumn(
                name: "reconhecimento_id",
                table: "ReconhecimentoItens",
                newName: "ReconhecimentoId");

            migrationBuilder.RenameIndex(
                name: "IX_ReconhecimentoItens_usuario_id",
                table: "ReconhecimentoItens",
                newName: "IX_ReconhecimentoItens_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "pontos",
                table: "Recompensas",
                newName: "Pontos");

            migrationBuilder.RenameColumn(
                name: "usuario_id",
                table: "Recompensas",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "tipo_recompensa",
                table: "Recompensas",
                newName: "TipoRecompensa");

            migrationBuilder.RenameColumn(
                name: "data_resgate",
                table: "Recompensas",
                newName: "DataResgate");

            migrationBuilder.RenameColumn(
                name: "recompensa_id",
                table: "Recompensas",
                newName: "RecompensaId");

            migrationBuilder.RenameIndex(
                name: "IX_Recompensas_usuario_id",
                table: "Recompensas",
                newName: "IX_Recompensas_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "Localizacoes",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "Localizacoes",
                newName: "Latitude");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "Localizacoes",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "nome_localizacao",
                table: "Localizacoes",
                newName: "NomeLocalizacao");

            migrationBuilder.RenameColumn(
                name: "localizacao_id",
                table: "Localizacoes",
                newName: "LocalizacaoId");

            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "ItensReciclados",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "localizacao",
                table: "ItensReciclados",
                newName: "Localizacao");

            migrationBuilder.RenameColumn(
                name: "usuario_id",
                table: "ItensReciclados",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "tipo_item",
                table: "ItensReciclados",
                newName: "TipoItem");

            migrationBuilder.RenameColumn(
                name: "data_coleta",
                table: "ItensReciclados",
                newName: "DataColeta");

            migrationBuilder.RenameColumn(
                name: "item_id",
                table: "ItensReciclados",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensReciclados_usuario_id",
                table: "ItensReciclados",
                newName: "IX_ItensReciclados_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "valor_configuracao",
                table: "Configuracoes",
                newName: "ValorConfiguracao");

            migrationBuilder.RenameColumn(
                name: "usuario_id",
                table: "Configuracoes",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "nome_configuracao",
                table: "Configuracoes",
                newName: "NomeConfiguracao");

            migrationBuilder.RenameColumn(
                name: "configuracao_id",
                table: "Configuracoes",
                newName: "ConfiguracaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Configuracoes_usuario_id",
                table: "Configuracoes",
                newName: "IX_Configuracoes_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Configuracoes_Usuarios_UsuarioId",
                table: "Configuracoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensReciclados_Usuarios_UsuarioId",
                table: "ItensReciclados",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recompensas_Usuarios_UsuarioId",
                table: "Recompensas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReconhecimentoItens_Usuarios_UsuarioId",
                table: "ReconhecimentoItens",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Configuracoes_Usuarios_UsuarioId",
                table: "Configuracoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensReciclados_Usuarios_UsuarioId",
                table: "ItensReciclados");

            migrationBuilder.DropForeignKey(
                name: "FK_Recompensas_Usuarios_UsuarioId",
                table: "Recompensas");

            migrationBuilder.DropForeignKey(
                name: "FK_ReconhecimentoItens_Usuarios_UsuarioId",
                table: "ReconhecimentoItens");

            migrationBuilder.RenameColumn(
                name: "Localizacao",
                table: "ReconhecimentoItens",
                newName: "localizacao");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "ReconhecimentoItens",
                newName: "usuario_id");

            migrationBuilder.RenameColumn(
                name: "UrlImagem",
                table: "ReconhecimentoItens",
                newName: "url_imagem");

            migrationBuilder.RenameColumn(
                name: "TipoItem",
                table: "ReconhecimentoItens",
                newName: "tipo_item");

            migrationBuilder.RenameColumn(
                name: "DataReconhecimento",
                table: "ReconhecimentoItens",
                newName: "data_reconhecimento");

            migrationBuilder.RenameColumn(
                name: "ReconhecimentoId",
                table: "ReconhecimentoItens",
                newName: "reconhecimento_id");

            migrationBuilder.RenameIndex(
                name: "IX_ReconhecimentoItens_UsuarioId",
                table: "ReconhecimentoItens",
                newName: "IX_ReconhecimentoItens_usuario_id");

            migrationBuilder.RenameColumn(
                name: "Pontos",
                table: "Recompensas",
                newName: "pontos");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Recompensas",
                newName: "usuario_id");

            migrationBuilder.RenameColumn(
                name: "TipoRecompensa",
                table: "Recompensas",
                newName: "tipo_recompensa");

            migrationBuilder.RenameColumn(
                name: "DataResgate",
                table: "Recompensas",
                newName: "data_resgate");

            migrationBuilder.RenameColumn(
                name: "RecompensaId",
                table: "Recompensas",
                newName: "recompensa_id");

            migrationBuilder.RenameIndex(
                name: "IX_Recompensas_UsuarioId",
                table: "Recompensas",
                newName: "IX_Recompensas_usuario_id");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Localizacoes",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Localizacoes",
                newName: "latitude");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Localizacoes",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "NomeLocalizacao",
                table: "Localizacoes",
                newName: "nome_localizacao");

            migrationBuilder.RenameColumn(
                name: "LocalizacaoId",
                table: "Localizacoes",
                newName: "localizacao_id");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "ItensReciclados",
                newName: "quantidade");

            migrationBuilder.RenameColumn(
                name: "Localizacao",
                table: "ItensReciclados",
                newName: "localizacao");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "ItensReciclados",
                newName: "usuario_id");

            migrationBuilder.RenameColumn(
                name: "TipoItem",
                table: "ItensReciclados",
                newName: "tipo_item");

            migrationBuilder.RenameColumn(
                name: "DataColeta",
                table: "ItensReciclados",
                newName: "data_coleta");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ItensReciclados",
                newName: "item_id");

            migrationBuilder.RenameIndex(
                name: "IX_ItensReciclados_UsuarioId",
                table: "ItensReciclados",
                newName: "IX_ItensReciclados_usuario_id");

            migrationBuilder.RenameColumn(
                name: "ValorConfiguracao",
                table: "Configuracoes",
                newName: "valor_configuracao");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Configuracoes",
                newName: "usuario_id");

            migrationBuilder.RenameColumn(
                name: "NomeConfiguracao",
                table: "Configuracoes",
                newName: "nome_configuracao");

            migrationBuilder.RenameColumn(
                name: "ConfiguracaoId",
                table: "Configuracoes",
                newName: "configuracao_id");

            migrationBuilder.RenameIndex(
                name: "IX_Configuracoes_UsuarioId",
                table: "Configuracoes",
                newName: "IX_Configuracoes_usuario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Configuracoes_Usuarios_usuario_id",
                table: "Configuracoes",
                column: "usuario_id",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensReciclados_Usuarios_usuario_id",
                table: "ItensReciclados",
                column: "usuario_id",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recompensas_Usuarios_usuario_id",
                table: "Recompensas",
                column: "usuario_id",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReconhecimentoItens_Usuarios_usuario_id",
                table: "ReconhecimentoItens",
                column: "usuario_id",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
