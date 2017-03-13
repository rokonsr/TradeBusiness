using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using TradeBusiness.Areas.Admin.Models;
using TradeBusiness.DAL;

namespace TradeBusiness.Areas.Admin.BLL
{
    public class AdminUserPartialBLL
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;
        private void BuildModelForAdminUser(DbDataReader objDataReader, AdminUserPartial objAdminUserPartial)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "AdminUserId":
                        if (!Convert.IsDBNull(objDataReader["AdminUserId"]))
                        {
                            objAdminUserPartial.AdminUserId = Convert.ToByte(objDataReader["AdminUserId"]);
                        }
                        break;
                    case "AdminUsername":
                        if (!Convert.IsDBNull(objDataReader["AdminUsername"]))
                        {
                            objAdminUserPartial.AdminUsername = objDataReader["AdminUsername"].ToString();
                        }
                        break;
                    case "UserRole":
                        if (!Convert.IsDBNull(objDataReader["UserRole"]))
                        {
                            objAdminUserPartial.UserRole = Convert.ToByte(objDataReader["UserRole"].ToString());
                        }
                        break;
                    case "UserRoleName":
                        if (!Convert.IsDBNull(objDataReader["UserRoleName"]))
                        {
                            objAdminUserPartial.UserRoleName = objDataReader["UserRoleName"].ToString();
                        }
                        break;
                    case "EmailAddress":
                        if (!Convert.IsDBNull(objDataReader["EmailAddress"]))
                        {
                            objAdminUserPartial.EmailAddress = objDataReader["EmailAddress"].ToString();
                        }
                        break;
                    case "MaxCompany":
                        if (!Convert.IsDBNull(objDataReader["MaxCompany"]))
                        {
                            objAdminUserPartial.MaxCompany = Convert.ToByte(objDataReader["MaxCompany"].ToString());
                        }
                        break;
                    case "MaxBranch":
                        if (!Convert.IsDBNull(objDataReader["MaxBranch"]))
                        {
                            objAdminUserPartial.MaxBranch = Convert.ToByte(objDataReader["MaxBranch"].ToString());
                        }
                        break;
                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objAdminUserPartial.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objAdminUserPartial.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objAdminUserPartial.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objAdminUserPartial.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objAdminUserPartial.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objAdminUserPartial.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objAdminUserPartial.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public string DeleteAdminUser(int id)
        {
            int noRowCount = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("AdminUserId", id);
            //objDbCommand.AddInParameter("CreatedBy", objAdminUser.CreatedBy);         

            try
            {
                noRowCount = objDataAccess.ExecuteNonQuery(objDbCommand, "[dbo].uspDeleteAdminUser", CommandType.StoredProcedure);

                if (noRowCount > 0)
                {
                    objDbCommand.Transaction.Commit();
                    return "Save Successfully";
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

        public AdminUserPartial GetAdminUser(int id)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            AdminUserPartial objAdminUserPartial = new AdminUserPartial();
            List<AdminUserPartial> objAdminUserList = new List<AdminUserPartial>();

            try
            {
                objDbCommand.AddInParameter("AdminUserId", id);
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[dbo].[uspGetAdminUser]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                        objAdminUserPartial = new AdminUserPartial();
                        this.BuildModelForAdminUser(objDbDataReader, objAdminUserPartial);

                        objAdminUserList.Add(objAdminUserPartial);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
            finally
            {
                if (objDbDataReader != null)
                {
                    objDbDataReader.Close();
                }
                objDataAccess.Dispose(objDbCommand);
            }

            return objAdminUserPartial;
        }

        //Edit Admin User Information
        public string UpdateAdminUser(AdminUserPartial objAdminUserPartial)
        {
            int noRowCount = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("AdminUserId", objAdminUserPartial.AdminUserId);
            objDbCommand.AddInParameter("UserRole", objAdminUserPartial.UserRole);
            objDbCommand.AddInParameter("EmailAddress", objAdminUserPartial.EmailAddress);
            objDbCommand.AddInParameter("MaxCompany", objAdminUserPartial.MaxCompany);
            objDbCommand.AddInParameter("MaxBranch", objAdminUserPartial.MaxBranch);
            //objDbCommand.AddInParameter("CreatedBy", objAdminUser.CreatedBy);         

            try
            {
                noRowCount = objDataAccess.ExecuteNonQuery(objDbCommand, "[dbo].uspUpdateAdminUser", CommandType.StoredProcedure);

                if (noRowCount > 0)
                {
                    objDbCommand.Transaction.Commit();
                    return "Save Successfully";
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