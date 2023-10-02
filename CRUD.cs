using MySql.Data.MySqlClient;
using System.Reflection;

namespace cssteamscraping;

internal class CRUD
{
    private readonly string groupColumns = "`id`, `gid`, `name`, `name_indicated`, `name_unicoded`, `abbreviation`, `abbreviation_indicated`, `abbreviation_unicoded`, `url`, `avatar`, `member_count`, `created_at`, `owner`, `owner_steamid`";
    private readonly string groupValues = "@id, @gid, @name, @name_indicated, @name_unicoded, @abbreviation, @abbreviation_indicated, @abbreviation_unicoded, @url, @avatar, @member_count, @created_at, @owner, @owner_steamid";
    private MySqlConnection connection = Database.CreateConnection(); 
    public void InsertGroup(Group group)
    {
        using (connection);

        string query = $"INSERT INTO groups ({groupColumns}) VALUES ({groupValues})";

        using MySqlCommand command = new(query, connection);

        foreach (PropertyInfo property in group.GetType().GetProperties())
        {
            if (property.GetValue(group) == null)
            {
                command.Parameters.AddWithValue($"@{property.Name}", DBNull.Value);
                continue;
            }

            command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(group));
        }

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
        finally
        {
            connection.Close();
        }
    }

    public void UpdateGroup(Group group)
    {
        using (connection);

        string query = $"UPDATE groups SET gid = @gid, name = @name, name_indicated = @name_indicated, name_unicoded = @name_unicoded, abbreviation = @abbreviation, abbreviation_indicated = @abbreviation_indicated, abbreviation_unicoded = @abbreviation_unicoded, url = @url, avatar = @avatar, member_count = @member_count, created_at = @created_at, owner = @owner, owner_steamid = @owner_steamid WHERE id = @id";

        using MySqlCommand command = new(query, connection);
        foreach (PropertyInfo property in group.GetType().GetProperties())
        {
            if (property.Name == "id")
            {
                continue;
            }

            if (property.GetValue(group) == null)
            {
                command.Parameters.AddWithValue($"@{property.Name}", DBNull.Value);
                continue;
            }

            command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(group));
        }

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
        finally
        {
            connection.Close();
        }
    }

    public void DeleteGroup(Group group)
    {
        using (connection);

        string query = $"DELETE FROM groups WHERE id = @id";

        using MySqlCommand command = new(query, connection);
        command.Parameters.AddWithValue("@id", group.id);

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
        finally
        {
            connection.Close();
        }
    }

    public Group GetGroup(int id)
    {
        using (connection);

        string query = $"SELECT * FROM groups WHERE id = @id";

        using MySqlCommand command = new(query, connection);
        command.Parameters.AddWithValue("@id", id);

        try
        {
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            Group group = new();
            while (reader.Read())
            {
                foreach (PropertyInfo property in group.GetType().GetProperties())
                {
                    if (reader.IsDBNull(reader.GetOrdinal(property.Name)))
                    {
                        continue;
                    }

                    property.SetValue(group, reader.GetValue(reader.GetOrdinal(property.Name)));
                }
            }
            return group;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
        finally
        {
            connection.Close();
        }
    }
}