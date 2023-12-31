﻿using Ecosistemas_Marinos.Entidades;
using Ecosistemas_Marinos.Exceptions;
using Ecosistemas_Marinos.Interfaces_Repositorios;
using EcosistemasMarinos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AccessData.EntityFramework.SQL
{
    public class RepositorioUsuario: IRepositorioUsuario
    {
        private EcosistemaMarinoContext _context;
        private IRepositorioConfiguracion config;

        public RepositorioUsuario(IRepositorioConfiguracion config)
        {
            _context = new EcosistemaMarinoContext();
            this.config = config;
        }

        void IRepositorio<Usuario>.Add(Usuario usuario)
        {
            try
            {
                usuario.EsValido(config);
                usuario.Encriptada = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasenia);               
                _context.usuarios.Add(usuario);
                _context.SaveChanges();
            }
            catch (UserException userException)
            {
                throw userException;
            }
            catch (Exception)
            {
                throw new Exception(@"Error al agregar el usuario ");
            }
        }


        public void Delete(Usuario t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerPorAlias(string alias)
        {
            return _context.usuarios.Where(u => u.Alias == alias).FirstOrDefault();
        }

        public void Remove(Usuario t)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario t)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerUsuario(string alias, string password)
        {
            return _context.usuarios.Where(u => u.Alias.Equals(alias) && u.Contrasenia.Equals(password) ).FirstOrDefault();
        }
    }
}
