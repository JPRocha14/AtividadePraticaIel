using Microsoft.AspNetCore.Mvc;
using IELStudentManager.Data;
using IELStudentManager.Models;

namespace IELStudentManager.Controllers
{
    public class EstudanteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstudanteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Exibir a lista de estudantes
        public IActionResult Index()
        {
            var estudantes = _context.Estudantes.ToList();
            return View(estudantes);
        }

        // Exibir página de criação de um novo estudante
        public IActionResult Create()
        {
            return View();
        }

        // Processar o formulário de criação
        [HttpPost]
        public IActionResult Create(Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                // Formatar o CPF
                estudante.CPF = FormatarCPF(estudante.CPF);
                
                _context.Estudantes.Add(estudante);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudante);
        }

        private string FormatarCPF(string cpf)
        {
            // Remove qualquer coisa que não seja número
            cpf = new string(cpf.Where(char.IsDigit).ToArray());
            
            // Se o CPF não tiver 11 dígitos, retorna o valor original
            if (cpf.Length != 11)
                return cpf;
            
            // Formatar CPF no formato xxx.xxx.xxx-xx
            return string.Format("{0:000\\.000\\.000-00}", Convert.ToInt64(cpf));
        }

        // Exibir estudantes com base na pesquisa
        public IActionResult Search(string searchTerm = null)
        {
            searchTerm = searchTerm?.Trim();

            var estudantes = string.IsNullOrEmpty(searchTerm)
                ? _context.Estudantes.ToList()
                : _context.Estudantes
                     .Where(e => e.Nome.ToLower().Contains(searchTerm.ToLower()) ||  // Nome: insensível a maiúsculas/minúsculas
                        e.CPF.Contains(searchTerm) ||                        // CPF: texto exato
                        e.Endereco.ToLower().Contains(searchTerm.ToLower()))   // Endereço: insensível a maiúsculas/minúsculas
                    .ToList();

            return View(estudantes);  // Chama a view Index passando os estudantes filtrados
        }

        // Ação GET para confirmar exclusão
        public IActionResult Delete(int id)
        {
            var estudante = _context.Estudantes.Find(id);
            if (estudante == null)
            {
                return NotFound();  // Se não encontrar o estudante, retorna 404
            }
            return View(estudante);  // Exibe a página de confirmação de exclusão
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var estudante = _context.Estudantes.Find(id);
            if (estudante != null)
            {
                _context.Estudantes.Remove(estudante);
                _context.SaveChanges();  // Realiza a exclusão no banco de dados
            }
            // Redireciona para a página de lista de estudantes após a exclusão
            return RedirectToAction("Index");  // Certifique-se de que isso é o que está ocorrendo
        }
    }
}
