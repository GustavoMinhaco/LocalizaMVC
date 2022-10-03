using LocalizaMVC.Domain.Entidades;
using LocalizaMVC.Domain.Interfaces;
using LocalizaMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        ApplicationDbContext _usuarioContext;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _usuarioContext = context;
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _usuarioContext.Add(usuario);
            await _usuarioContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> GetByIdAsync(int? id)
        {
            return await _usuarioContext.Usuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            return await _usuarioContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> RemoveAsync(Usuario usuario)
        {
            _usuarioContext.Remove(usuario);
            await _usuarioContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            _usuarioContext.Update(usuario);
            await _usuarioContext.SaveChangesAsync();
            return usuario;
        }
    }
}
