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
                    this.InitializeListGenericSessionProducts();
                    this.LoadGenericGrid();
                }
                else if (Convert.ToBoolean(Session["IsformFamilies"]))
                {
                    this.LoadContentFamily();
                    this.LoadDepartament(false);
                    this.InitializeListGenericSessionFamily();
                    this.LoadGenericGrid();
                }
                else
                {
                    this.LoadContentDepartament();
                    this.InitializeListGenericSessionDepartament();
                    this.LoadGenericGrid();
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
        private void LoadSelectedProduct(int productId)
        {
            if (Session["ListGenericSession"] == null)
            {
                Response.Redirect("frmGenericABM.aspx");
            }

            List<Product> products = (List<Product>)Session["ListGenericSession"];
            foreach (Product oneP in products)
            {
                if (oneP.ProductId == productId)
                {
                    this.txtGenericId.Text = oneP.ProductId.ToString();
                    this.txtProductCode.Text = oneP.ProductCode;
                    this.txtGenericName.Text = oneP.ProductName;
                    this.txtProductDescription.Text = oneP.ProductDescription;
                    this.txtProductColor.Text = oneP.ProductColor;
                    ViewState["productStockSize"] = oneP.ProductStockSize;
                    ViewState["productStockSizeShoes"] = oneP.ProductStockSizeShoes;
                    this.txtProductPrice.Text = oneP.ProductPrice.ToString();
                }
            }
        }
        private void LoadSelectedFamily(int familyId)
        {
            if (Session["ListGenericSession"] == null)
            {
                Response.Redirect("frmGenericABM.aspx");
            }

            List<Product> products = (List<Product>)Session["ListGenericSession"];
            foreach (Product oneP in products)
            {
                if (oneP.FamilyId == familyId)
                {
                    this.txtGenericId.Text = oneP.FamilyId.ToString();
                    this.txtGenericName.Text = oneP.FamilyName;
                }
            }
        }
        private void LoadSelectedDepartament(int departamentId)
        {
            if (Session["ListGenericSession"] == null)
            {
                Response.Redirect("frmGenericABM.aspx");
            }

            List<Product> products = (List<Product>)Session["ListGenericSession"];
            foreach (Product oneP in products)
            {
                if (oneP.DepartamentId == departamentId)
                {
                    this.txtGenericId.Text = oneP.DepartamentId.ToString();
                    this.txtGenericName.Text = oneP.DepartamentName;
                }
            }
        }
        private void LoadGenericGrid()
        {
            List<Product> products = (List<Product>)Session["ListGenericSession"];
            if (products.Count > 0)
            {
                gvGeneric.DataSource = products;
                gvGeneric.DataBind();
            }
            else
            {
                gvGeneric.Visible = false;
                lblMessageGv.Text = "No hay productos en la base de datos.";
            }
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
                this.InitializeListGenericSessionProducts();
                this.LoadGenericGrid();
            }
            else if (Convert.ToBoolean(Session["IsformFamilies"]))
            {
                this.shoppingOnline.InsertFamily(MappingFamilyData());
                this.InitializeListGenericSessionFamily();
                this.LoadGenericGrid();
            }
            else
            {
                this.shoppingOnline.InsertDepartament(MappingDepartamentData());
                this.InitializeListGenericSessionDepartament();
                this.LoadGenericGrid();
            }
            this.ResetContents();
        }
        protected void btnGenericUpdate_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["IsformProducts"]))
            {
                //De haber más colores, que ingrese el mismo código.
                this.shoppingOnline.UpdateProduct(MappingProductData());
                this.InitializeListGenericSessionProducts();
                this.LoadGenericGrid();
            }
            else if (Convert.ToBoolean(Session["IsformFamilies"]))
            {
                this.shoppingOnline.UpdateFamily(MappingFamilyData());
                this.InitializeListGenericSessionFamily();
                this.LoadGenericGrid();
            }
            else
            {
                this.shoppingOnline.UpdateDepartament(MappingDepartamentData());
                this.InitializeListGenericSessionDepartament();
                this.LoadGenericGrid();
            }
            this.ResetContents();
        }
        protected void btnGenericDelete_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["IsformProducts"]))
            {
                //De haber más colores, que ingrese el mismo código.
                this.shoppingOnline.DeleteProduct(Convert.ToInt32(this.txtGenericId.Text));
                this.InitializeListGenericSessionProducts();
                this.LoadGenericGrid();
            }
            else if (Convert.ToBoolean(Session["IsformFamilies"]))
            {
                this.shoppingOnline.DeleteFamily(Convert.ToInt32(this.txtGenericId.Text));
                this.InitializeListGenericSessionFamily();
                this.LoadGenericGrid();
            }
            else
            {
                this.shoppingOnline.DeleteDepartament(Convert.ToInt32(this.txtGenericId.Text));
                this.InitializeListGenericSessionDepartament();
                this.LoadGenericGrid();
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
            pDepartament.DepartamentId = Convert.ToInt32(this.txtGenericId.Text);
            pDepartament.DepartamentName = this.txtGenericName.Text;
            pDepartament.DepartamentIsTypeShoes = this.rdbTypeShoesY.Checked;

            return pDepartament;
        }
        private Family MappingFamilyData()
        {
            Family pFamily = new Family();
            pFamily.FamilyId = Convert.ToInt32(this.txtGenericId.Text);
            pFamily.FamilyName = this.txtGenericName.Text;
            pFamily.DepartamentId = Convert.ToInt32(this.ddlGenericDepartament.SelectedItem.Value);
            pFamily.DepartamentIsTypeShoes = this.rdbTypeShoesY.Checked;

            return pFamily;
        }
        private void ResetContents()
        {
            if (this.ddlProductGenre.SelectedIndex != -1)
            {
                this.ddlProductGenre.SelectedIndex = 0;
            }
            if (this.ddlGenericDepartament.SelectedIndex != -1)
            {
                this.ddlGenericDepartament.SelectedIndex = 0;
            }
            if (this.ddlProductDepartamentFamily.SelectedIndex != -1)
            {
                this.ddlProductDepartamentFamily.SelectedIndex = 0;
            }
            if (this.ddlProductSize.SelectedIndex != -1)
            {
                this.ddlProductSize.SelectedIndex = 0;
            }
            this.txtGenericId.Text = "";
            this.txtProductCode.Text = "";
            this.txtGenericName.Text = "";
            this.txtProductDescription.Text = "";
            this.txtProductColor.Text = "";
            this.rdbTypeShoesN.Checked = true;
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

        protected void gvGeneric_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;

            if (Convert.ToBoolean(Session["IsformProducts"]))
            {
                int productId = Convert.ToInt32(gridView.SelectedRow.Cells[4].Text);
                this.LoadSelectedProduct(productId);
            }
            else if (Convert.ToBoolean(Session["IsformFamilies"]))
            {
                int familyId = Convert.ToInt32(gridView.SelectedRow.Cells[0].Text);
                this.LoadSelectedFamily(familyId);
            }
            else
            {
                int departamentId = Convert.ToInt32(gridView.SelectedRow.Cells[2].Text);
                this.LoadSelectedDepartament(departamentId);
            }
        }
        protected void gvGeneric_DataBound(object sender, EventArgs e)
        {
            GridView gridView = (GridView)sender;

            if (Convert.ToBoolean(Session["IsformProducts"]))
            {
                this.ShowGridProducts(gridView);
            }
            else if (Convert.ToBoolean(Session["IsformFamilies"]))
            {
                this.ShowGridFamilies(gridView);
            }
            else
            {
                this.ShowGridDepartaments(gridView);
            }
        }

        private void InitializeListGenericSessionProducts()
        {
            List<Product> products = shoppingOnline.GetProducts();
            Session["ListGenericSession"] = products;
        }
        private void InitializeListGenericSessionFamily()
        {
            List<Family> families = shoppingOnline.GetFamilies();
            List<Product> productFamilies = new List<Product>();
            foreach (Family oneF in families)
            {
                Product oneP = new Product();
                oneP.DepartamentId = -1;
                oneP.DepartamentName = "empty";
                oneP.FamilyId = oneF.FamilyId;
                oneP.FamilyName = oneF.FamilyName;
                oneP.ProductId = -1;
                oneP.ProductCode = "empty";
                oneP.ProductName = "empty";
                productFamilies.Add(oneP);
            }
            Session["ListGenericSession"] = productFamilies;
        }
        private void InitializeListGenericSessionDepartament()
        {
            List<Departament> departaments = shoppingOnline.GetDepartaments();
            List<Product> productDepartaments = new List<Product>();
            foreach (Departament oneD in departaments)
            {
                Product oneP = new Product();
                oneP.DepartamentId = oneD.DepartamentId;
                oneP.DepartamentName = oneD.DepartamentName;
                oneP.FamilyId = -1;
                oneP.FamilyName = "empty";
                oneP.ProductId = -1;
                oneP.ProductCode = "empty";
                oneP.ProductName = "empty";
                productDepartaments.Add(oneP);
            }
            Session["ListGenericSession"] = productDepartaments;
        }

        private void ShowGridProducts(GridView gridView)
        {
            gridView.Columns[0].Visible = false;
            gridView.Columns[1].Visible = false;
            gridView.Columns[2].Visible = false;
            gridView.Columns[3].Visible = false;
            gridView.Columns[4].Visible = true;
            gridView.Columns[5].Visible = true;
            gridView.Columns[6].Visible = true;
            gridView.Columns[7].Visible = true;
            gridView.Columns[8].Visible = true;
        }
        private void ShowGridDepartaments(GridView gridView)
        {
            gridView.Columns[0].Visible = false;
            gridView.Columns[1].Visible = false;
            gridView.Columns[2].Visible = true;
            gridView.Columns[3].Visible = true;
            gridView.Columns[4].Visible = false;
            gridView.Columns[5].Visible = false;
            gridView.Columns[6].Visible = false;
            gridView.Columns[7].Visible = false;
            gridView.Columns[8].Visible = false;
        }
        private void ShowGridFamilies(GridView gridView)
        {
            gridView.Columns[0].Visible = true;
            gridView.Columns[1].Visible = true;
            gridView.Columns[2].Visible = false;
            gridView.Columns[3].Visible = false;
            gridView.Columns[4].Visible = false;
            gridView.Columns[5].Visible = false;
            gridView.Columns[6].Visible = false;
            gridView.Columns[7].Visible = false;
            gridView.Columns[8].Visible = false;
        }

        protected void btnGenericReset_Click(object sender, EventArgs e)
        {
            this.ResetContents();
        }
    }
}