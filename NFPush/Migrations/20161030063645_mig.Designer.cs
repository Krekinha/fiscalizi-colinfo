using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NFPush;

namespace NFPush.Migrations
{
    [DbContext(typeof(NFPContext))]
    [Migration("20161030063645_mig")]
    partial class mig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("NFPush.Model.NFe.Classes.DFe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("NSU");

                    b.Property<string>("schema");

                    b.Property<string>("xmlDFe");

                    b.HasKey("ID");

                    b.ToTable("DFes");
                });
        }
    }
}
