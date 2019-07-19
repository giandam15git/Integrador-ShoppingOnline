using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shopping.Online._2_Domain.Entities;
using Shopping.Online._2_Domain.Entities_Business;
using static Shopping.Online.Resources.Enumerate;
using Shopping.Online.Resources;
using System.IO;

namespace Shopping.Online._1_Presentation
{
    public partial class frmGenericABM : System.Web.UI.Page
    {
        ShoppingOnline shoppingOnline = new ShoppingOnline();
        Product product = new Product();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToBoolean(Session["IsformProducts"]))
                {
                    ViewState["productStockSize"] = new int[8];
                    ViewState["productStockSizeShoes"] = new int[17];
                    this.LoadContentProduct();
                    this.LoadGenre();
                    this.LoadSize();
                    this.LoadDepartament(false);
                    this.LoadFamily();
                }
                else if (Convert.ToBoolean(Session["IsformFamilies"]))
                {
                    this.LoadContentFamily();
                    this.LoadDepartament(false);
                }
                else
                {
                    this.LoadContentDepartament();
                }
            }
        }

        #region LoadData
        private void LoadSize()
        {
            ddlProductSize.DataSource = null;
            ddlProductSize.DataSource = Enum.GetValues(typeof(ProductSizes));
            ddlProductSize.DataBind();
        }
        private void LoadSizeShoes()
        {
            ddlProductSize.DataSource = null;
            ddlProductSize.DataSource = Enum.GetValues(typeof(ProductSizeShoes));
            ddlProductSize.DataBind();
        }
        private void LoadGenre()
        {
            ddlProductGenre.DataSource = null;
            ddlProductGenre.DataSource = Enum.GetValues(typeof(ProductGenres));
            ddlProductGenre.DataBind();
        }
        private void LoadDepartament(bool isTypeShoes)
        {
            ddlGenericDepartament.DataSource = null;
            ddlGenericDepartament.DataSource = shoppingOnline.GetDepartaments(isTypeShoes);
            ddlGenericDepartament.DataValueField = "DepartamentId";
            ddlGenericDepartament.DataTextField = "DepartamentName";
            ddlGenericDepartament.DataBind();
        }
        private void LoadFamily(int departamentId = -1)
        {
            ddlProductDepartamentFamily.DataSource = null;
            ddlProductDepartamentFamily.DataSource = shoppingOnline.GetFamilies(departamentId);
            ddlProductDepartamentFamily.DataValueField = "FamilyId";
            ddlProductDepartamentFamily.DataTextField = "FamilyName";
            ddlProductDepartamentFamily.DataBind();
        }
        #endregion

        #region SelectedIndex
        protected void ddlProductGenre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlProductSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.ddlProductSize.SelectedIndex;
            if (index != 0)
            {
                if (this.rdbTypeShoesN.Checked)
                {
                    int[] productStockSize = (int[])ViewState["productStockSize"];
                    this.txtProductSizeStock.Text = Convert.ToString(productStockSize[index]);
                }
                else
                {
                    int[] productStockSizeShoes = (int[])ViewState["productStockSizeShoes"];
                    this.txtProductSizeStock.Text = Convert.ToString(productStockSizeShoes[index]);
                }
            }
        }
        protected void ddlGenericDepartament_SelectedIndexChanged(object sender, EventArgs e)
        {
            int departamentId = Convert.ToInt32(ddlGenericDepartament.SelectedItem.Value);
            this.LoadFamily(departamentId);
        }
        protected void ddlProductDepartamentFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            Convert.ToInt32(ddlProductDepartamentFamily.SelectedItem.Value);
        }
        #endregion

        #region Product, Departament and Fimily (Insert, Update, Delete)
        protected void btnGenericInsert_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["IsformProducts"]))
            {
                //De haber más colores, que ingrese el mismo código.
                this.shoppingOnline.InsertProduct(MappingProductData());
            }
            else if (Convert.ToBoolean(Session["IsformFamilies"]))
            {
                this.shoppingOnline.InsertFamily(MappingFamilyData());
            }
            else
            {
                this.shoppingOnline.InsertDepartament(MappingDepartamentData());
            }
            this.ResetContents();
        }
        protected void btnGenericUpdate_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["IsformProducts"]))
            {
                //De haber más colores, que ingrese el mismo código.
                this.shoppingOnline.UpdateProduct(MappingProductData());
            }
            else if (Convert.ToBoolean(Session["IsformFamilies"]))
            {
                this.shoppingOnline.UpdateFamily(MappingFamilyData());
            }
            else
            {
                this.shoppingOnline.UpdateDepartament(MappingDepartamentData());
            }
            this.ResetContents();
        }
        protected void btnGenericDelete_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["IsformProducts"]))
            {
                //De haber más colores, que ingrese el mismo código.
                this.shoppingOnline.DeleteProduct(Convert.ToInt32(this.txtGenericId.Text));
            }
            else if (Convert.ToBoolean(Session["IsformFamilies"]))
            {
                this.shoppingOnline.DeleteFamily(Convert.ToInt32(this.txtGenericId.Text));
            }
            else
            {
                this.shoppingOnline.DeleteDepartament(Convert.ToInt32(this.txtGenericId.Text));
            }
            this.ResetContents();
        }

        #endregion

        #region Auxiliary methods
        private Product MappingProductData()
        {
            Product pProduct = new Product();
            pProduct.ProductCode = this.txtProductCode.Text;
            pProduct.ProductName = this.txtGenericName.Text;
            pProduct.ProductDescription = this.txtProductDescription.Text;
            pProduct.ProductImage = this.LoadImage();
            pProduct.ProductGenre = ddlProductGenre.SelectedItem.Text; //(uint)Enum.Parse(typeof(ProductGenres), "HKEY_LOCAL_MACHINE"); Extraer valor por string
            pProduct.ProductColor = this.txtProductColor.Text;
            pProduct.ProductStockSize = (int[])ViewState["productStockSize"];
            pProduct.ProductStockSizeShoes = (int[])ViewState["productStockSizeShoes"];
            pProduct.ProductPrice = Convert.ToDecimal(this.txtProductPrice.Text);
            pProduct.FamilyId = Convert.ToInt32(this.ddlProductDepartamentFamily.SelectedValue);

            return pProduct;
        }
        private Departament MappingDepartamentData()
        {
            Departament pDepartament = new Departament();
            pDepartament.DepartamentName = this.txtGenericName.Text;
            pDepartament.DepartamentIsTypeShoes = this.rdbTypeShoesY.Checked;

            return pDepartament;
        }
        private Family MappingFamilyData()
        {
            Family pFamily = new Family();
            pFamily.FamilyName = this.txtGenericName.Text;
            pFamily.DepartamentId = Convert.ToInt32(this.ddlGenericDepartament.SelectedItem.Value);
            pFamily.DepartamentIsTypeShoes = this.rdbTypeShoesY.Checked;

            return pFamily;
        }
        public void LoadContentFamily()
        {
            this.divTitleProduct.Visible = false;
            this.divTitleFamily.Visible = true;
            this.divTitleDepartament.Visible = false;
            this.divProductCode.Visible = false;
            this.divGenericName.Visible = true;
            this.divProductDescription.Visible = false;
            this.divProductGenre.Visible = false;
            this.divProductColor.Visible = false;
            this.divGenericShoes.Visible = true;
            this.divGenericSelectedDepartament.Visible = true;
            this.divGenericSelectedFamiliy.Visible = false;
            this.divProductSize.Visible = false;
            this.divProductSizeStock.Visible = false;
            this.divProductImage.Visible = false;
            this.divProductPrice.Visible = false;
            this.btnGenericInsert.Text = "Ingresar Familia";
            this.btnGenericUpdate.Text = "Modificar Familia";
        }
        public void LoadContentDepartament()
        {
            this.divTitleProduct.Visible = false;
            this.divTitleFamily.Visible = false;
            this.divTitleDepartament.Visible = true;
            this.divProductCode.Visible = false;
            this.divGenericName.Visible = true;
            this.divProductDescription.Visible = false;
            this.divProductGenre.Visible = false;
            this.divProductColor.Visible = false;
            this.divGenericShoes.Visible = true;
            this.divGenericSelectedDepartament.Visible = false;
            this.divGenericSelectedFamiliy.Visible = false;
            this.divProductSize.Visible = false;
            this.divProductSizeStock.Visible = false;
            this.divProductImage.Visible = false;
            this.divProductPrice.Visible = false;
            this.btnGenericInsert.Text = "Ingresar Departamento";
            this.btnGenericUpdate.Text = "Modificar Departamento";
        }
        public void LoadContentProduct()
        {
            this.divTitleProduct.Visible = true;
            this.divTitleFamily.Visible = false;
            this.divTitleDepartament.Visible = false;
            this.divProductCode.Visible = true;
            this.divGenericName.Visible = true;
            this.divProductDescription.Visible = true;
            this.divProductGenre.Visible = true;
            this.divProductColor.Visible = true;
            this.divGenericShoes.Visible = true;
            this.divGenericSelectedDepartament.Visible = true;
            this.divGenericSelectedFamiliy.Visible = true;
            this.divProductSize.Visible = true;
            this.divProductSizeStock.Visible = true;
            this.divProductImage.Visible = true;
            this.divProductPrice.Visible = true;
            this.btnGenericInsert.Text = "Ingresar Producto";
            this.btnGenericUpdate.Text = "Modificar Producto";
        }
        public string LoadImage()
        {
            bool isTypeFile = false;
            if (FileUpload1.HasFile)
            {
                string extensionOfFile = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                string extension = ".jpg";
                if (extensionOfFile == extension)
                {
                    isTypeFile = true;
                }
            }
            if (isTypeFile)
            {
                return Convert.ToBase64String(FileUpload1.FileBytes);
            }
            else
            {
                lblMessageProduct.Text = "POr favor selecione una imagen con extension .jpg";
            }
            return "ERROR";
        }
        private void ResetContents()
        {
            this.txtGenericId.Text = "";
            this.txtProductCode.Text = "";
            this.txtGenericName.Text = "";
            this.txtProductDescription.Text = "";
            //this.ddlProductGenre.Text = "";
            this.txtProductColor.Text = "";
            this.rdbTypeShoesN.Checked = true;
            //this.ddlGenericDepartament.Text = "";
            //this.ddlProductDepartamentFamily.Text = "";
            //this.ddlProductSize.Text = "";
            this.txtProductSizeStock.Text = "0";
            this.txtProductPrice.Text = "";

        }
        #endregion

        protected void txtProductSizeStock_TextChanged(object sender, EventArgs e)
        {
            int index = this.ddlProductSize.SelectedIndex;

            if (index != 0 && this.rdbTypeShoesN.Checked)
            {
                int[] productStockSize = (int[])ViewState["productStockSize"]; //= Convert.ToInt32(txtProductSizeStock.Text);
                productStockSize[index] = Convert.ToInt32(txtProductSizeStock.Text);
                ViewState["productStockSize"] = productStockSize;
            }
            else
            {
                int[] productStockSizeShoes = (int[])ViewState["productStockSizeShoes"]; //= Convert.ToInt32(txtProductSizeStock.Text);
                productStockSizeShoes[index] = Convert.ToInt32(txtProductSizeStock.Text);
                ViewState["productStockSizeShoes"] = productStockSizeShoes;
            }
        }

        protected void rdbTypeShoes_CheckedChanged(object sender, EventArgs e)
        {
            if (ddlGenericDepartament.SelectedItem != null)
            {
                //Si es de tipo shoes, se va a cargar otro talle para zapatos.
                if (this.rdbTypeShoesY.Checked)
                {
                    this.LoadDepartament(true);
                    this.LoadSizeShoes();
                    int departamentId = Convert.ToInt32(ddlGenericDepartament.SelectedItem.Value);
                    this.LoadFamily(departamentId);
                    
                }
                else
                {
                    this.LoadDepartament(false);
                    this.LoadSize();
                    int departamentId = Convert.ToInt32(ddlGenericDepartament.SelectedItem.Value);
                    this.LoadFamily(departamentId);
                }
            }
        }
    }
}