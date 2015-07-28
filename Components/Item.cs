/*
' Copyright (c) 2015 Christoc.com
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
using System.Web.Caching;
using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Content;

namespace TAC.Modules.HelloWorld.Components
{
    [TableName("TAC_HelloWorld")]
    //setup the primary key for table
    [PrimaryKey("TextId", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("Items", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)

    public class Item
    {
        ///<summary>
        /// The ID of your object with the name of the ItemName
        ///</summary>
        public int TextId { get; set; }
        ///<summary>
        /// A string with the name of the ItemName
        ///</summary>
        public string HelloText { get; set; }

        ///<summary>
        /// A string with the description of the object
        ///</summary>

    }
}
