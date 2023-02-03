using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyecto_dominio;
using proyecto_negocio;

namespace winAppDiscos
{
    public partial class frmAltaDisco : Form
    {
        private Discos Discos = null;
        public frmAltaDisco()
        {
            InitializeComponent();
        }
        public frmAltaDisco(Discos Discos)
        {
            InitializeComponent();
            this.Discos = Discos;
            Text = "Modificar Disco";
        }
        private void lblUrl_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Discos dis = new Discos();
            DiscosNegocio neg =new  DiscosNegocio();
            try
            {
                if (Discos == null)
                    Discos = new Discos();
                Discos.titulo = txtTitulo.Text;
                Discos.canciones = int.Parse(txtCanciones.Text);
                Discos.url = txtUrl.Text;
                Discos.Estilo = (elemento)cbEstilo.SelectedItem;
                Discos.formato = (elemento)cbFormato.SelectedItem;

                if (Discos.Id != 0)
                {
                    neg.modificar(Discos);
                    MessageBox.Show("Modificado exitosamente");

                    
                }
                else {
                    neg.agregar(Discos);
                    MessageBox.Show("Agregado exitosamente");
                }
                Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void frmAltaDisco_Load(object sender, EventArgs e)
        {
            ElementoNegocio elem = new ElementoNegocio();
            try
            {
                cbEstilo.DataSource = elem.listar();
                cbEstilo.ValueMember = "Id";
                cbEstilo.DisplayMember = "Descripcion"; 
                cbFormato.DataSource = elem.listar2();
                cbFormato.ValueMember = "Id";
                cbFormato.DisplayMember = "Descripcion";

                if (Discos != null)
                {
                    txtTitulo.Text = Discos.titulo;
                    txtCanciones.Text =  Discos.canciones.ToString();
                    txtUrl.Text = Discos.url;
                    cargarImagen(Discos.url);
                    cbEstilo.SelectedValue = Discos.Estilo.Id;
                    cbFormato.SelectedValue = Discos.formato.Id;

                   
                }
            }
            catch ( Exception ex)
            {

                throw ex;
            }
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrl.Text);
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbAltaDisco.Load(imagen);
            }
            catch (Exception)
            {

                pbAltaDisco.Load("https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png");
            }

        }
    }
}
