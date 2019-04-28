using System;
using System.Collections.Generic;
using DemoApp.DAL;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

public class DbContextFixture : IDisposable
{
    public DatabaseContext databaseContext {get;}
    private bool disposed = false;
    SqliteConnection sqlConnect;
    public DbContextFixture(){
        sqlConnect = new SqliteConnection("DataSource=:memory:");
        sqlConnect.Open();
        databaseContext = new DatabaseContext(
            new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlite(sqlConnect).Options
        );
        var a = databaseContext.Database.EnsureCreated();
        var b = databaseContext.Database.EnsureDeleted();

        InitialData();
        databaseContext.SaveChanges();
    }

    ~DbContextFixture(){
        Dispose(false);
        GC.SuppressFinalize(this);
    }

    private void InitialData()
    {
        databaseContext.AddRange(new List<Products>{
            new Products { Name = "UnitNaja" }
        });
    }
    protected virtual void Dispose(bool disposing){
        if(!this.disposed)
            sqlConnect.Close();
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
    }
}