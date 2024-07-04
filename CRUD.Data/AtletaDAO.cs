using CRUD.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Data
{
    public class AtletaDAO
    {
        public List<Atleta> Listar()
        {
            List<Atleta> atletas = new List<Atleta>();

            try
            {
                using (SqlConnection oConexao = new SqlConnection(Conexao.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_LISTAR_ATLETAS", oConexao);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexao.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            atletas.Add(new Atleta
                            {
                                IdAtleta = Convert.ToInt32(dr["ID_ATLETA"].ToString()),
                                NomeCompleto = dr["NOME_COMPLETO"].ToString(),
                                Apelido = dr["APELIDO"].ToString(),
                                DataNascimento = Convert.ToDateTime(dr["DATA_NASCIMENTO"].ToString()),
                                Altura = Convert.ToDecimal(dr["ALTURA"].ToString()),
                                Peso = Convert.ToDecimal(dr["PESO"].ToString()),
                                Posicao = dr["POSICAO"].ToString(),
                                NroCamisa = Convert.ToInt32(dr["NRO_CAMISA"].ToString())
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return atletas;
        }

        public Atleta ObterPorId(int id)
        {
            Atleta atleta = new Atleta();

            try
            {
                using (SqlConnection oConexao = new SqlConnection(Conexao.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_OBTER_ATLETA_POR_ID", oConexao);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    oConexao.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if(dr.Read())
                        {
                            atleta.IdAtleta = Convert.ToInt32(dr["ID_ATLETA"].ToString());
                            atleta.NomeCompleto = dr["NOME_COMPLETO"].ToString();
                            atleta.Apelido = dr["APELIDO"].ToString();
                            atleta.DataNascimento = Convert.ToDateTime(dr["DATA_NASCIMENTO"].ToString());
                            atleta.Altura = Convert.ToDecimal(dr["ALTURA"].ToString());
                            atleta.Peso = Convert.ToDecimal(dr["PESO"].ToString());
                            atleta.Posicao = dr["POSICAO"].ToString();
                            atleta.NroCamisa = Convert.ToInt32(dr["NRO_CAMISA"].ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return atleta;
        }

        public bool Criar(Atleta atleta)
        {
            bool result = false;

            try
            {
                using (SqlConnection oConexao = new SqlConnection(Conexao.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_CRIAR_ATLETA", oConexao);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOME_COMPLETO", atleta.NomeCompleto);
                    cmd.Parameters.AddWithValue("@APELIDO", atleta.Apelido);
                    cmd.Parameters.AddWithValue("@DATA_NASCIMENTO", atleta.DataNascimento);
                    cmd.Parameters.AddWithValue("@ALTURA", atleta.Altura);
                    cmd.Parameters.AddWithValue("@PESO", atleta.Peso);
                    cmd.Parameters.AddWithValue("@POSICAO", atleta.Posicao);
                    cmd.Parameters.AddWithValue("@NRO_CAMISA", atleta.NroCamisa);

                    oConexao.Open();

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                        result = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public bool Editar(Atleta atleta)
        {
            bool result = false;

            try
            {
                using (SqlConnection oConexao = new SqlConnection(Conexao.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_EDITAR_ATLETA", oConexao);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_ATLETA", atleta.IdAtleta);
                    cmd.Parameters.AddWithValue("@NOME_COMPLETO", atleta.NomeCompleto);
                    cmd.Parameters.AddWithValue("@APELIDO", atleta.Apelido);
                    cmd.Parameters.AddWithValue("@DATA_NASCIMENTO", atleta.DataNascimento);
                    cmd.Parameters.AddWithValue("@ALTURA", atleta.Altura);
                    cmd.Parameters.AddWithValue("@PESO", atleta.Peso);
                    cmd.Parameters.AddWithValue("@POSICAO", atleta.Posicao);
                    cmd.Parameters.AddWithValue("@NRO_CAMISA", atleta.NroCamisa);

                    oConexao.Open();

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                        result = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public bool Eliminar(int id)
        {
            bool result = false;

            try
            {
                using (SqlConnection oConexao = new SqlConnection(Conexao.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINAR_ATLETA", oConexao);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_ATLETA", id);

                    oConexao.Open();

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                        result = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
