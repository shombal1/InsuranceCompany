using System.Reflection;
using System.Text.Json;
using InsuranceCompany.Domain.Models.Items;
using InsuranceCompany.Storage.Entities;
using InsuranceCompany.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany.Storage;

public class InsuranceCompanyDbContext(DbContextOptions<InsuranceCompanyDbContext> options) : DbContext(options)
{
    public DbSet<AgentAgreementEntity> AgentAgreements { get; set; }
    public DbSet<AgentEntity> Agents { get; set; }
    public DbSet<ContractEntity> Contracts { get; set; }
    public DbSet<ContractRiskEntity> ContractRisks { get; set; }
    public DbSet<FaceEntity> Faces { get; set; }
    public DbSet<IKPEntity> IKPs { get; set; }
    public DbSet<LOBEntity> LOBs { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductMetafieldEntity> ProductsMetafield { get; set; }
    public DbSet<ProductRiskEntity> ProductRisks { get; set; }
    public DbSet<StatusAgentContractEntity> StatusesAgentContracts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(InsuranceCompanyDbContext))!);

        GenerateSeed(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private void GenerateSeed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LOBEntity>().HasData([
            new() { Id = 1, Name = "КАСКО" },
            new() { Id = 2, Name = "ОСАГО" },
            new() { Id = 3, Name = "Страхование путешественников" },
            new() { Id = 4, Name = "Страхование от несчастных случаев" }
        ]);

        modelBuilder.Entity<StatusAgentContractEntity>().HasData([
            new() { Id = 1, Name = "Проект" },
            new() { Id = 2, Name = "Действует" },
            new() { Id = 3, Name = "Завершен" },
            new() { Id = 4, Name = "Расторгнут" }
        ]);

        ProductEntity product1 = new()
        {
            Id = 1,
            Name = "отпуск вашй мечты",
            LOBId = 3,
            Description = "Гибкая система выбора нужных вам рисков и на требуемый срок",
            Formula = "(P1+P2*M2S+P3*M3S)*M1I",
            Active = true
        };

        modelBuilder.Entity<ProductEntity>().HasData(product1);

        modelBuilder.Entity<ProductRiskEntity>().HasData([
            new()
            {
                Id = 1, Name = "Несчастный случай", Key = "P1", Premium = 5000, InsuranceSum = 500_000, Active = true,
                ProductId = product1.Id
            },
            new()
            {
                Id = 2, Name = "Утрата багажа", Key = "P2", Premium = 1000, InsuranceSum = 10_000, Active = false,
                ProductId = product1.Id
            },
            new()
            {
                Id = 3, Name = "Задержка рейса", Key = "P3", Premium = 2000, InsuranceSum = 20_000, Active = false,
                ProductId = product1.Id
            }
        ]);

        modelBuilder.Entity<ProductMetafieldEntity>().HasData([
            new()
            {
                Id = 1,
                JsonData = JsonSerializer.Serialize(new ItemInputBox()
                {
                    Index = 1,
                    Key = "M1I",
                    Type = ItemType.InputBox,
                    Description = "количество дней в путешествие"
                }),
                ProductId = product1.Id,
                Type = Enums.ProductMetafieldType.InputBox
            },
            new()
            {
                Id = 2,
                JsonData = JsonSerializer.Serialize(new ItemComboBox()
                {
                    Index = 2,
                    Key = "M2S",
                    Type = ItemType.InputBox,
                    Description = "Период отдыха",
                    Values = [new("высокий", 1.2), new ComboBoxValue("низкий", 0.9)]
                }),
                Type = Enums.ProductMetafieldType.ComboBox,
                ProductId = product1.Id
            },
            new()
            {
                Id = 3,
                JsonData = JsonSerializer.Serialize(new ItemComboBox()
                {
                    Index = 3,
                    Key = "M3S",
                    Type = ItemType.InputBox,
                    Description = "Напрвление полета",
                    Values = [new("Европа", 1), new ComboBoxValue("Турций", 1.2), new ComboBoxValue("ОАЭ", 1.1)]
                }),
                Type = Enums.ProductMetafieldType.ComboBox,
                ProductId = product1.Id
            }
        ]);

        var faceEntity1 = new FaceEntity
        {
            Id = 1,
            Type = FaceType.Legal,
            FirstName = "Александр",
            SecondName = "Сергеевич",
            Lastname = "Иванов",
            DateBirth = new DateTime(1990, 5, 10, 0, 0, 0, DateTimeKind.Utc),
            Name = "Александр Сергеевич Иванов",
            INN = 1234567890
        };

        var faceEntity2 = new FaceEntity
        {
            Id = 2,
            Type = FaceType.Natural,
            FirstName = "Мария",
            SecondName = "Викторовна",
            Lastname = "Петрова",
            DateBirth = new DateTime(1985, 11, 20, 0, 0, 0, DateTimeKind.Utc),
            Name = "Мария Викторовна Петрова",
            INN = 1876543210
        };

        modelBuilder.Entity<FaceEntity>().HasData([
            faceEntity1,
            faceEntity2
        ]);

        var ikp1 = new IKPEntity()
        {
            Id = 1,
            Name = "Главный"
        };

        var ikp2 = new IKPEntity()
        {
            Id = 2,
            Name = "Вспомогательный"
        };

        modelBuilder.Entity<IKPEntity>().HasData([
            ikp1,
            ikp2
        ]);

        var agent1 = new AgentEntity()
        {
            Id = 1,
            DateCreate = new DateTime(2024, 1, 20, 0, 0, 0, DateTimeKind.Utc),
            DateBegin = new DateTime(2024, 1, 21, 0, 0, 0, DateTimeKind.Utc),
            DateEnd = new DateTime(2024, 2, 20, 0, 0, 0, DateTimeKind.Utc),
            FaceId = 1,
            IKPId = 1,
            StatusId = 1
        };

        var agent2 = new AgentEntity()
        {
            Id = 2,
            DateCreate = new DateTime(2024, 2, 20, 0, 0, 0, DateTimeKind.Utc),
            DateBegin = new DateTime(2024, 2, 21, 0, 0, 0, DateTimeKind.Utc),
            DateEnd = new DateTime(2024, 3, 20, 0, 0, 0, DateTimeKind.Utc),
            FaceId = 2,
            IKPId = 2,
            StatusId = 2
        };

        modelBuilder.Entity<AgentEntity>().HasData([
            agent1,
            agent2
        ]);
    }
}