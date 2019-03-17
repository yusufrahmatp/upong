using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseInit : MonoBehaviour
{
    private string dbPath;
    public Text highscoreText;

    private void Start()
    {
        dbPath = "URI=file:" + Application.persistentDataPath + "/HighscoreDatabase.db";

        // CreateSchema();
        // ClearHighscore();
        // InsertScore("Ilham", 9999);

        InsertScore(PlayerPrefs.GetString("name", "NONAME"), PlayerPrefs.GetInt("score", 0));
        
        GetHighScores(10);
    }

    public void CreateSchema()
    {
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS 'high_score' ( " +
                                  "  'id' INTEGER PRIMARY KEY, " +
                                  "  'name' TEXT NOT NULL, " +
                                  "  'score' INTEGER NOT NULL" +
                                  ");";

                var result = cmd.ExecuteNonQuery();
                Debug.Log("create schema: " + result);
            }
        }
    }

    public void InsertScore(string highScoreName, int score)
    {
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO high_score (name, score) " +
                                  "VALUES (@Name, @Score);";

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "Name",
                    Value = highScoreName
                });

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "Score",
                    Value = score
                });

                var result = cmd.ExecuteNonQuery();
                Debug.Log("insert score: " + result);
            }
        }
    }

    public void ClearHighscore()
    {
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM high_score WHERE 1=1";
                var result = cmd.ExecuteNonQuery();
                Debug.Log("delete all high_score row:" + result);
            }
        }
    }

    public void GetHighScores(int limit)
    {
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM high_score ORDER BY score DESC LIMIT @Count;";

                cmd.Parameters.Add(new SqliteParameter
                {
                    ParameterName = "Count",
                    Value = limit
                });

                Debug.Log("scores (begin)");
                highscoreText.text = "";
                var reader = cmd.ExecuteReader();
                int count = 1;
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var highScoreName = reader.GetString(1);
                    var score = reader.GetInt32(2);
                    var text = string.Format("{0}. {1} ~ {2}\n", count, highScoreName, score);
                    highscoreText.text += text;
                    count++;
                    Debug.Log(text);
                }
                Debug.Log("scores (end)");
            }
        }
    }
}
