using webapi.Models;

public class BuildingService : IService
{
    AppDb _db;

    public BuildingService(AppDb db)
    {
        _db = db;
    }

    public async Task<List<Buildings>> GetAll()
    {
        List<Buildings> _buildings = new List<Buildings>();

        if (_db.Connection.State == System.Data.ConnectionState.Closed)
        {
            await _db.Connection.OpenAsync();
        }

        using var cmd = _db.Connection.CreateCommand();
        cmd.CommandText = "SELECT id, name FROM ocu.buildings";
        var reader = await cmd.ExecuteReaderAsync();
        using (reader)
        {
            while (await reader.ReadAsync())
            {
                var building = new Buildings()
                {
                    Id = reader.GetString("id"),
                    Name = reader.GetString("name")
                };
                _buildings.Add(building);
            }
        }
        
        return (_buildings);
    }

    // public async Task<bool> Save(Buildings building)
    // {
    //     var b = await GetById(building.Id);
    //     if (b == null)
    //     {
    //         return await CreateBuilding(building.Name, building.Id);
    //     }
    //     else
    //     {
    //         return await UpdateBuilding(building.Name, building.Id);
    //     }
    // }

    public async Task<bool> CreateBuilding(string name, string id)
    {
        if (_db.Connection.State == System.Data.ConnectionState.Closed)
        {
            await _db.Connection.OpenAsync();
        }

        using var cmd = _db.Connection.CreateCommand();
        cmd.CommandText = $"INSERT INTO ocu.buildings (id, name) VALUES ('{id}', '{name}')";
        var reader = await cmd.ExecuteNonQueryAsync();

        return true;
    }

    public async Task<bool> UpdateBuilding(string name, string id)
    {
        if (_db.Connection.State == System.Data.ConnectionState.Closed)
        {
            await _db.Connection.OpenAsync();
        }
 
        using var cmd = _db.Connection.CreateCommand();
        cmd.CommandText = $"UPDATE ocu.buildings SET name = '{name}' WHERE id =  '{id}'";
        var reader = await cmd.ExecuteNonQueryAsync();

        return true;
    }

    public async Task<bool> DeleteById(string id)
    {
        if (_db.Connection.State == System.Data.ConnectionState.Closed)
        {
            await _db.Connection.OpenAsync();
        }

        using var cmd = _db.Connection.CreateCommand();
        cmd.CommandText = $"DELETE FROM ocu.buildings WHERE id = '{id}'";
        var reader = await cmd.ExecuteNonQueryAsync();

        return true;
    }

    public async Task<Buildings> GetById(string id)
    {
        if (_db.Connection.State == System.Data.ConnectionState.Closed)
        {
            await _db.Connection.OpenAsync();
        }

        var _buildings = new Buildings();
        using var cmd = _db.Connection.CreateCommand();
        cmd.CommandText = "SELECT id, name FROM ocu.buildings";
        var reader = await cmd.ExecuteReaderAsync();

        using (reader)
        {
            while (await reader.ReadAsync())
            {
                var building = new Buildings()
                {
                    Id = reader.GetString("id"),
                    Name = reader.GetString("name")
                };
            }
        }

        return (_buildings);
    }
}