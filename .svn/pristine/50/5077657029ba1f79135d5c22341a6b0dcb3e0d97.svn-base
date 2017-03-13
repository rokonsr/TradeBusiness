using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using TradeBusiness.Areas.Admin.Models;
using TradeBusiness.DAL;

namespace TradeBusiness.Areas.Admin.BLL
{
    //created by ataur
    public class UserInfoPartialBLL
    {
        private IDataAccess objDataAccess;
        private DbCommand objDbCommand;
        private void BuildModelForUserInfoPartial(DbDataReader objDataReader, UserInfoPartial objUserInfoPartial)
        {
            DataTable objDataTable = objDataReader.GetSchemaTable();
            foreach (DataRow dr in objDataTable.Rows)
            {
                String column = dr.ItemArray[0].ToString();
                switch (column)
                {
                    case "UserId":
                        if (!Convert.IsDBNull(objDataReader["UserId"]))
                        {
                            objUserInfoPartial.UserId = Convert.ToByte(objDataReader["UserId"]);
                        }
                        break;
                    case "Username":
                        if (!Convert.IsDBNull(objDataReader["Username"]))
                        {
                            objUserInfoPartial.Username = objDataReader["Username"].ToString();
                        }
                        break;
                    case "BranchId":
                        if (!Convert.IsDBNull(objDataReader["BranchId"]))
                        {
                            objUserInfoPartial.BranchId = Convert.ToByte(objDataReader["BranchId"].ToString());
                        }
                        break;
                    case "BranchName":
                        if (!Convert.IsDBNull(objDataReader["BranchName"]))
                        {
                            objUserInfoPartial.BranchName = objDataReader["BranchName"].ToString();
                        }
                        break;

                    case "IsActive":
                        if (!Convert.IsDBNull(objDataReader["IsActive"]))
                        {
                            objUserInfoPartial.IsActive = Convert.ToBoolean(objDataReader["IsActive"].ToString());
                        }
                        break;
                    case "CreatedBy":
                        if (!Convert.IsDBNull(objDataReader["CreatedBy"]))
                        {
                            objUserInfoPartial.CreatedBy = Convert.ToInt16(objDataReader["CreatedBy"]);
                        }
                        break;
                    case "CreatedDate":
                        if (!Convert.IsDBNull(objDataReader["CreatedDate"]))
                        {
                            objUserInfoPartial.CreatedDate = Convert.ToDateTime(objDataReader["CreatedDate"].ToString());
                        }
                        break;
                    case "UpdatedBy":
                        if (!Convert.IsDBNull(objDataReader["UpdatedBy"]))
                        {
                            objUserInfoPartial.UpdatedBy = Convert.ToInt16(objDataReader["UpdatedBy"].ToString());
                        }
                        break;
                    case "UpdatedDate":
                        if (!Convert.IsDBNull(objDataReader["UpdatedDate"]))
                        {
                            objUserInfoPartial.UpdatedDate = Convert.ToDateTime(objDataReader["UpdatedDate"].ToString());
                        }
                        break;
                    case "SortedBy":
                        if (!Convert.IsDBNull(objDataReader["SortedBy"]))
                        {
                            objUserInfoPartial.SortedBy = Convert.ToByte(objDataReader["SortedBy"].ToString());
                        }
                        break;
                    case "Remarks":
                        if (!Convert.IsDBNull(objDataReader["Remarks"]))
                        {
                            objUserInfoPartial.Remarks = objDataReader["Remarks"].ToString();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        //Get UserInfo by UserId for Edit
        public UserInfoPartial GetUserInfo(int id)
        {
            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.ReadCommitted);
            DbDataReader objDbDataReader = null;
            UserInfoPartial objUserInfoPartial=new UserInfoPartial();
            List<UserInfoPartial> objUserInfoPartialList=new List<UserInfoPartial>();

            try
            {
                objDbCommand.AddInParameter("UserId", id);
                objDbCommand.AddInParameter("AdminUserId", SessionUtility.TBSessionContainer.UserID);
                objDbDataReader = objDataAccess.ExecuteReader(objDbCommand, "[dbo].[uspGetUserInfo]", CommandType.StoredProcedure);

                if (objDbDataReader.HasRows)
                {
                    while (objDbDataReader.Read())
                    {
                       objUserInfoPartial=new UserInfoPartial();
                        this.BuildModelForUserInfoPartial(objDbDataReader, objUserInfoPartial);

                       objUserInfoPartialList.Add(objUserInfoPartial);
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

            return objUserInfoPartial;
        }

        // Update Specific UserInfo
        public string UpdateUserInfo(UserInfoPartial objUserInfoPartial)
        {
            int noRowCount = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);

            objDbCommand.AddInParameter("UserId", objUserInfoPartial.UserId);
            objDbCommand.AddInParameter("Username", objUserInfoPartial.Username);           
            objDbCommand.AddInParameter("BranchId", objUserInfoPartial.BranchId);
            objDbCommand.AddInParameter("IsActive", objUserInfoPartial.IsActive);
            //updated by which Admin!
            objDbCommand.AddInParameter("UpdatedByAdminUserId", SessionUtility.TBSessionContainer.UserID); 

            try
            {
                noRowCount = objDataAccess.ExecuteNonQuery(objDbCommand, "[dbo].uspUpdateUserInfo", CommandType.StoredProcedure);

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

        //Delete Specific UserInfo
        public string DeleteUserInfo(int id)
        {
            int noRowCount = 0;

            objDataAccess = DataAccess.NewDataAccess();
            objDbCommand = objDataAccess.GetCommand(true, IsolationLevel.Serializable);
            objDbCommand.AddInParameter("UserId", id);
            //objDbCommand.AddInParameter("CreatedBy", objAdminUser.CreatedBy);         

            try
            {
                noRowCount = objDataAccess.ExecuteNonQuery(objDbCommand, "[dbo].uspDeleteUserInfo", CommandType.StoredProcedure);

                if (noRowCount > 0)
                {
                    objDbCommand.Transaction.Commit();
                    return "Delete Successfully";
                }
                else
                {
                    objDbCommand.Transaction.Rollback();
                    return "Delete Failed";
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