﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace OdeToCode.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    namespace OdeToCode.Data.Migrations
    {
        public partial class AddOdeToCodeUser : Migration
        {
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.AddColumn<string>(
                    name: "FavoriteRestaurant",
                    table: "AspNetUsers",
                    type: "nvarchar(1024)",
                    maxLength: 1024,
                    nullable: true);
            }

            protected override void Down(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.DropColumn(
                    name: "FavoriteRestaurant",
                    table: "AspNetUsers");
            }
        }
    }
}
