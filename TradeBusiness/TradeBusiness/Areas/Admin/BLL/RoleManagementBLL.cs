using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using TradeBusiness.Areas.Admin.Models;
using TradeBusiness.DAL;

namespace TradeBusiness.Areas.Admin.BLL
{
    public class RoleManagementBLL
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;
        private void BuildModelForRole(DbDataReader objDataReader, RoleInfo objRoleInfo)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "RoleId":
                        if (!Convert.IsDBNull(objDataReader["RoleId"]))
                        {
                            objRoleInfo.RoleId = Convert.ToByte(objDataReader["RoleId"]);
                        }
                        break;
                    case "RoleName":
                        if (!Convert.IsDBNull(objDataReader["RoleName"]))
                        {
                            objRoleInfo.RoleName = objDataReader["RoleName"].ToString();
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objRoleInfo.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objRoleInfo.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objRoleInfo.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objRoleInfo.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objRoleInfo.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objRoleInfo.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objRoleInfo.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public string CreateRole(RoleInfo objRole) //updated by enamul
        {
            int noOfAffacted = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("RoleName", objRole.RoleName);
            objDbCommand.AddInParameter("CreatedBy", SessionUtility.TBSessionContainer.UserID);

            try
            {
                objDataAccess.ExecuteNonQuery(objDbCommand, "[dbo].[uspCreateRole]", CommandType.StoredProcedure);
                
                if (noOfAffacted > 0)
                {
                    objDbCommand.Transaction.Commit();
                    return "Save Successful";
                }
                else
                {
                    objDbCommand.Transaction.Rollback();
                    return "Save Failed";
                }
            }
            catch (Exception ex)
            {
                objDbCommand.Transaction.Rollback();
                throw new Exception("Database Error Occured", ex);
            }
            finally
            {
                objDataAccess.Dispose(objDbCommand);
            }
        }
    }
}