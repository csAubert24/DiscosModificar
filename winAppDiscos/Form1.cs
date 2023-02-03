using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyecto_dominio;
using proyecto_negocio;


namespace winAppDiscos
{
    public partial class Catalogo : Form
    {
        private List<Discos> listaPokemos;
        public Catalogo()
        {
            InitializeComponent();
        }

        private void Catalogo_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Discos seleccionado = (Discos) dgvDiscos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.url);
        }


        private void cargar()
        {
            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                listaPokemos = negocio.listar();
                dgvDiscos.DataSource = listaPokemos;
                dgvDiscos.Columns[0].Visible = false;
                dgvDiscos.Columns[2].Visible = false;
                cargarImagen(listaPokemos[0].url);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbDiscos.Load(imagen);
            }
            catch (Exception)
            {

                pbDiscos.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaDisco nuevo = new frmAltaDisco();
            nuevo.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Discos seleccionado = (Discos)dgvDiscos.CurrentRow.DataBoundItem;
            
            frmAltaDisco nuevo = new frmAltaDisco(seleccionado);
            nuevo.ShowDialog();
            cargar();
        }
    }
}
