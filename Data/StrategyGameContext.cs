using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StrategyGame.Models;

namespace StrategyGame.Data;

public partial class StrategyGameContext : DbContext
{
    public StrategyGameContext()
    {
    }

    public StrategyGameContext(DbContextOptions<StrategyGameContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Armor> Armors { get; set; }

    public virtual DbSet<Backpack> Backpacks { get; set; }

    public virtual DbSet<Hero> Heroes { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Legion> Legions { get; set; }

    public virtual DbSet<Monster> Monsters { get; set; }

    public virtual DbSet<Weapon> Weapons { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Armor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Armor__3214EC076A9415A6");

            entity.ToTable("Armor");

            entity.Property(e => e.DefensePercentage)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Name).HasMaxLength(40);
        });

        modelBuilder.Entity<Backpack>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Backpack__3214EC07514A6DB0");

            entity.ToTable("Backpack");

            entity.HasIndex(e => e.HeroId, "UQ_Backpack_Heroid").IsUnique();

            entity.HasOne(d => d.Hero).WithOne(p => p.Backpack)
                .HasForeignKey<Backpack>(d => d.HeroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Backpack_Hero");

            entity.HasMany(d => d.Items).WithMany(p => p.BackPacks)
                .UsingEntity<Dictionary<string, object>>(
                    "BackPackItem",
                    r => r.HasOne<Item>().WithMany()
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK_BackPackItem_Item"),
                    l => l.HasOne<Backpack>().WithMany()
                        .HasForeignKey("BackPackId")
                        .HasConstraintName("FK_BackPackItem_Backpack"),
                    j =>
                    {
                        j.HasKey("BackPackId", "ItemId").HasName("PK__BackPack__3759BBF93E100BE8");
                        j.ToTable("BackPackItem");
                    });
        });

        modelBuilder.Entity<Hero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hero__3214EC076E97809B");

            entity.HasIndex(h => h.Name)
                  .HasDatabaseName("IX_Hero_Name");

            entity.ToTable("Hero");

            entity.Property(e => e.Health)
                .HasDefaultValue(100m)
                .HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Name).HasMaxLength(40);

            entity.HasOne(d => d.EquippedArmorNavigation).WithMany(p => p.Heroes)
                .HasForeignKey(d => d.EquippedArmor)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Hero_Armor");

            entity.HasOne(d => d.EquippedWeaponNavigation).WithMany(p => p.Heroes)
                .HasForeignKey(d => d.EquippedWeapon)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Hero_Weapon");

            entity.HasOne(d => d.Legion).WithMany(p => p.Heroes)
                .HasForeignKey(d => d.LegionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Hero_Legion");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Item__3214EC0785D3B0CE");

            entity.ToTable("Item");

            entity.Property(e => e.ItemName).HasMaxLength(40);
        });

        modelBuilder.Entity<Legion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Legion__3214EC07A9651F52");

            entity.ToTable("Legion");

            entity.Property(e => e.Name).HasMaxLength(40);
        });

        modelBuilder.Entity<Monster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Monster__3214EC078720EC3B");

            entity.ToTable("Monster");

            entity.Property(e => e.Damage).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Weapon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Weapon__3214EC07D51BCEBC");

            entity.ToTable("Weapon");

            entity.Property(e => e.Damage).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Name).HasMaxLength(40);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
