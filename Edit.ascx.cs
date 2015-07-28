/*
' Copyright (c) 2015  Christoc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using DotNetNuke.Entities.Users;
using TAC.Modules.HelloWorld.Components;
using DotNetNuke.Services.Exceptions;

namespace TAC.Modules.HelloWorld
{
    /// -----------------------------------------------------------------------------
    /// <summary>   
    /// The Edit class is used to manage content
    /// 
    /// Typically your edit control would be used to create new content, or edit existing content within your module.
    /// The ControlKey for this control is "Edit", and is defined in the manifest (.dnn) file.
    /// 
    /// Because the control inherits from hello01ModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Edit : TAC.Modules.HelloWorld.Hello01ModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Implement your edit logic for your module
                if (!Page.IsPostBack)
                {
                    //get a list of users to assign the user to the Object


                    //check if we have an ID passed in via a querystring parameter, if so, load that item to edit.
                    //ItemId is defined in the ItemModuleBase.cs file
                    if (ItemId > 0)
                    {
                        var tc = new ItemController();

                        var t = tc.GetItem(ItemId);
                        if (t != null)
                        {
                            txtName.Text = t.HelloText;
                        }
                    }
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var t = new Item();
            var tc = new ItemController();

            if (ItemId > 0)
            {
                t = tc.GetItem(ItemId);
                t.HelloText = txtName.Text.Trim();

            }
            else
            {
                t = new Item()
                {

                    HelloText = txtName.Text.Trim(),

                };
            }



            if (t.TextId > 0)
            {
                tc.UpdateItem(t);
            }
            else
            {
                tc.CreateItem(t);
            }
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }
    }
}