using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTicketDashboard.Models
{

    
    public class CardUsers
    {
        public object Id { get; set; }

        public object firstName { get; set; }

        public object lastName { get; set; }

        public object middleName { get; set; }

        public object CardNumber { get; set; }

        public object CardType { get; set; }

        public object Address { get; set; }

        public object Mobilenumber { get; set; }

        public object EmailId { get; set; }

        public object flag { get; set; }
    }

    public class Alerts
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string MessageTypeId { get; set; }
        public string StatusId { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }
    }
    public class Notifications
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string MessageTypeId { get; set; }
        public string StatusId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
    }
    public class Btpos
    {

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int POSId { get; set; }
        public string Status { get; set; }
        public string IMEI { get; set; }
        public string Location { get; set; }

    }

    public class BtposRecords
    {

        public int Id { get; set; }
        public string RecordData { get; set; }
        public int POSID { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Downloaded { get; set; }

        public DateTime LastDownloadtime { get; set; }

        public int IsDirty { get; set; }

        public char insupddelflag { get; set; }

    }

    public class btposgroups
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Desc { get; set; }
        public string Active { get; set; }
        public string Code { get; set; }

    }
    public class master
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Code { get; set; }
        public string Subcat { get; set; }
        public string Active { get; set; }

    }
    public class detail
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public int PerUnitPrice { get; set; }
        public string ReorderPoint { get; set; }
        public int AvailableQty { get; set; }


    }
    public class roledetails
    {
        public int Id { get; set; }


        public string ObjectName { get; set; }

        public string Path { get; set; }

    }
    public class roles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Active { get; set; }
        public string IsPublic { get; set; }
        public string Company { get; set; }
        public int CompanyId { get; set; }


    }
    public class Blocklist
    {
        public string Id { get; set; }
        public int ItemId { get; set; }
        public string ItemTypeId { get; set; }
        public string Formdate { get; set; }
        public string Todate { get; set; }
        public string Active { get; set; }
        public string Desc { get; set; }
        public string Reason { get; set; }
        public string Blockedby { get; set; }
        public string UnBlockedby { get; set; }
        public string Blockedon { get; set; }
        public string UnBlockedon { get; set; }

        public string insupddelflag { get; set; }

    }
    public class Country
    {
        //Id, Name, Latitude, Longitude,ISOCode, HasOperations
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; }
        public string HasOperations { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }

    public class Cards
    {
        public object CardId;
        public object TransactionId;
        public object TransactionNo;
        public object TransactionDateTime;
        public object TransactionName;
        public object TransactionType;
        public object TransactionAmount;
        public object TransactionStatus;
        public object TransactionLoc;
        public object TransactionMode;
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
        public string CardModel { get; set; }
        public string CardCategory { get; set; }
        public string Customer { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
        public int StatusId { get; set; }

        public string flag { get; set; }

        public int id { get; set; }

        public int UserId { get; set; }

        public int CardStatus { get; set; }

        public string PIN { get; set; }

        public int CVV2 { get; set; }

        public int CVV { get; set; }

        public DateTime ValidTillDate { get; set; }

        public DateTime EstimatedEndDate { get; set; }

        public DateTime EstimatedStartDate { get; set; }

        public int ReferenceId { get; set; }

        public string NameOnCard { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmaiId { get; set; }

        public string MobileNumber { get; set; }

        public string Address { get; set; }

        public string MiddleName { get; set; }

        public object EmailId { get; set; }
    }
    public class CardStatuses
    {
        public int Id { get; set; }
        public int Active { get; set; }
        public string CardStatus { get; set; }
        public string Desc1 { get; set; }
        public int Typegrpid { get; set; }
    }


    public class Payables
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public int MasterId { get; set; }
        public string Paidby { get; set; }

    }
    public class PayablesMaster
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string PaidFor { get; set; }
        public string Desc { get; set; }

    }
    public class UserLogin
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public string LoginInfo { set; get; }
        public string Passkey { set; get; }
        public string Salt { set; get; }
        public string Active { set; get; }

    }
    public class userroles
    {
        public int Id { set; get; }
        public int UserId { set; get; }
        public int CompanyId { set; get; }
        public int RoleId { set; get; }
        public int flag { set; get; }
        public string Passkey { set; get; }

        public string insupdflag { set; get; }

    }

    public class STATE
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
        public string Code { get; set; }
        public string Active { get; set; }


    }

    public class SMSProviderConfig
    {

        public int Id { get; set; }
        public string ProviderName { get; set; }
        public string BTPOSGRPID { get; set; }
        public string Active { get; set; }
        public int UserId { get; set; }
        public string Passkey { get; set; }

    }
    public class ReceivingsMaster
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ReceivedFor { get; set; }
        public string Desc { get; set; }

    }
    public class Receivings
    {

        public int Id { get; set; }
        public string Amount { get; set; }
        public int MasterId { get; set; }
        public string ReceivedBy { get; set; }

    }
    public class Paymentgateway
    {

        public int Id { get; set; }
        public string ProviderName { get; set; }
        public string BTPOSGRPID { get; set; }
        public string Active { get; set; }
        public int UserId { get; set; }
        public string Passkey { get; set; }
        public string Url { get; set; }
        public string Testurl { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }


    }
    public class ZipCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Active { get; set; }

    }

    public class Routes
    {
        public int Id { set; get; }
        public string RouteName { set; get; }
        public string Code { set; get; }
        public string Description { set; get; }
        public int Active { set; get; }
        public decimal Distance { set; get; }
        public string Source { set; get; }
        public string Destination { set; get; }
        public int SourceId { set; get; }
        public int DestinationId { set; get; }
    }

    public class Transaction
    {
        public int Id { get; set; }

        public string TransCode { get; set; }

        public string TransType { get; set; }

        public DateTime Date { get; set; }

        public string TransId { get; set; }

        public int TotalAmt { get; set; }

        public string PaymentId { get; set; }

        public string BTPOSid { get; set; }

    }

    public class EditHistory
    {

        public string Field { get; set; }

        public string SubItem { get; set; }

        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public string ChangedBy { get; set; }

        public string ChangedType { get; set; }
    }

    public class EditHistoryDetails
    {

        public int EditHistoryId { get; set; }

        public string FromValue { get; set; }

        public string ToValue { get; set; }

        public string ChangeType { get; set; }

        public string Field1 { get; set; }

        public string Field2 { get; set; }
    }

    public class TypeGroups
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Active { get; set; }
        public string insupddelflag { get; set; }
    }

    public class Types
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Active { get; set; }



        public string TypeGroupId { get; set; }

        public string ListKey { get; set; }

        public string Listvalue { get; set; }
        public string insupddelflag { get; set; }
    }

    public class FleetOwner
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string BTPOSgroupid { get; set; }

        public string Active { get; set; }

    }

    public class TroubleTicketingCategories
    {
        public int active { get; set; }

        public string desc { get; set; }

        public int Id { get; set; }

        public string TTCategory { get; set; }

        public int typegrpid { get; set; }

    }

    public class TransactionType
    {
        public int active { get; set; }

        public string desc { get; set; }

        public int Id { get; set; }

        public string TransactionTypes { get; set; }

        public int typegrpid { get; set; }

    }
    public class Inventory1
    {

        public int InventoryId { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int AvailableQty { get; set; }

        public int Category { get; set; }
        public int SubCategory { get; set; }
        public int PerUnitPrice { get; set; }

        public int ReorderPont { get; set; }
        public int Active { get; set; }
        public string insupdflag { get; set; }

    }
    public class Expenses
    {
        public int amount { get; set; }

        public string Date { get; set; }

        public string desc { get; set; }

        public int Id { get; set; }

        public int MasterId { get; set; }

        public string paidBy { get; set; }

        public string paidFor { get; set; }

        public int transactionId { get; set; }

    }
    public class LicensePayments
    {
        public DateTime expiryOn { get; set; }

        public int Id { get; set; }

        public string licenseFor { get; set; }

        public int licenseId { get; set; }

        public string licenseType { get; set; }

        public DateTime paidon { get; set; }

        public DateTime renewedon { get; set; }

        public string transId { get; set; }

    }
    public class BTPOSInventorySales
    {
        public int amount { get; set; }

        public string code { get; set; }

        public int Id { get; set; }

        public int inventoryId { get; set; }

        public int perunit { get; set; }

        public int quantity { get; set; }

        public string soldon { get; set; }

        public int transactionId { get; set; }

        public string transactiontype { get; set; }

    }

    public class BTPOSDetails
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string CompanyId { get; set; }
        public string IMEI { get; set; }
        public string POSID { get; set; }
        public int StatusId { get; set; }
        public string ipconfig { get; set; }
        public string fleetowner { get; set; }
        public int? fleetownerid { get; set; }
        public int active { get; set; }
        public int POSTypeId { get; set; }
        public DateTime? ActivatedOn { get; set; }
        public decimal PerUnitPrice { get; set; }
        public string PONum { get; set; }
        public string insupdflag { get; set; }

    }
    public class VehicleDetails
    {
        public int busId { get; set; }

        public int busTypeId { get; set; }

        public int conductorId { get; set; }

        public string conductorName { get; set; }

        public int driverId { get; set; }

        public string driverName { get; set; }

        public int fleetOwnerId { get; set; }

        public string CompanyName { get; set; }

        public int Id { get; set; }

        public int POSID { get; set; }

        public string RegNo { get; set; }

        public string route { get; set; }

        public string Status { get; set; }

        public int statusid { get; set; }
        public int Active { get; set; }
        public string insupdflag { get; set; }
    }

    public class RoutesConfiguration
    {
        public int distanceFromDest { get; set; }

        public int distanceFromLastStop { get; set; }

        public int distanceFromPrevStop { get; set; }

        public int distanceFromSource { get; set; }

        public int Id { get; set; }

        public int routeId { get; set; }

        public string stops { get; set; }

    }

    public class CompanyGroups
    {
        public CompanyGroups[] m = null;
        //public List<CompanyGroups> list { get; set; }
        public int active { get; set; }

        public string admin { get; set; }

        public int adminId { get; set; }

        public string code { get; set; }

        public string desc { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public string Fax { get; set; }
        public string EmailId { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }

        public int FleetSize{get;set;}
        public int StaffSize{get;set;}
        public string AlternateAddress { get; set; }
        //public string TemporaryAddress{get;set;} 
        public string Logo { get; set; }

        public string insupdflag { get; set; }

    }


    //Jagan Updated On18th Aug Start
    public class DriversGroups
    {
        
        public DriversGroups[] p = null;
        //public List<DriversGroups> list { get; set; }
        public string flag {get; set;}
        public int DId {get; set;}
        public string CompanyId { get; set; }
        public string NAme {get; set;}
        public string Address {get; set;}
        public string City {get; set;}
        public string Pin {get; set;}
        public string PAddress {get; set;}
        public string PCity {get; set;}
        public string PPin {get; set;}
        public string OffMobileNo {get; set;}
        public string PMobNo {get; set;}
        public DateTime? DOB {get; set;}
        public DateTime? DOJ {get; set;}
        public string BloodGroup {get; set;}
        public string LicenceNo {get; set;}
        public DateTime? LiCExpDate {get; set;}
        public string BadgeNo {get; set;}
        public DateTime? BadgeExpDate {get; set;}
        public string Remarks { get; set; }
        public string VehicleModelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string PermanentAddress { get; set; }
        public string PermanentPin { get; set; }
        public string EmailId { get; set; }
        public string DriverCode { get; set; }
        public string FleetOwner { get; set; }

    }
    //Jagan Updated On18th Aug End

    public class VehiclesGroups
    {
        
        public VehiclesGroups[] o = null;
        //public List<VehiclesGroups> list3 { get; set; }
        public string flag { get; set; }
        public int Id { get; set; }
        public string CompanyId { get; set; }
        public int VID { get; set; }
        public string RegistrationNo { get; set; }
        public string vehicleType { get; set; }
        public int FleetOwner { get; set; }
        public string ChasisNo { get; set; }
        public string Engineno { get; set; }
        public DateTime? RoadTaxDate { get; set; }
        public int HasAC { get; set; }
        public DateTime? InsDate { get; set; }
        public string PolutionNo { get; set; }
        public DateTime? PolExpDate { get; set; }
        public string RCBookNo { get; set; }
        public DateTime? RCExpDate { get; set; }
        public int StatusId { get; set; }
        public int IsVerified { get; set; }
        public string VehicleCode { get; set; }
        public string ModelYear { get; set; }
        public int IsDriverowned { get; set; }
        public int DriverId { get; set; }
        public DateTime? EntryDate { get; set; }
        public string Country { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleGroup { get; set; }
    }


    public class CardsGroup
    {

        public CardsGroup[] cg = null;
        //public List<VehiclesGroups> list3 { get; set; }
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public string CardModel { get; set; }
        public string CardType  { get; set; }
        public string CardCategory { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
        public string Customer { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public string insupdflag { get; set; }
    }

    public class DriverVehicleAssignGroup
    {
        public DriverVehicleAssignGroup[] dva = null;
        public string inspudflag { get; set; }
        public int DId { get; set; }
        public string CompanyId { get; set; }
        public string NAme { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public string PAddress { get; set; }
        public string PCity { get; set; }
        public string PPin { get; set; }
        public string OffMobileNo { get; set; }
        public string PMobNo { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DOJ { get; set; }
        public string BloodGroup { get; set; }
        public string LicenceNo { get; set; }
        public DateTime? LiCExpDate { get; set; }
        public string BadgeNo { get; set; }
        public DateTime? BadgeExpDate { get; set; }
        public string Remarks { get; set; }
        public int Id { get; set; }
        public int VID { get; set; }
        public string RegistrationNo { get; set; }
        public string Type { get; set; }
        public string OwnerName { get; set; }
        public string ChasisNo { get; set; }
        public string Engineno { get; set; }
        public DateTime? RoadTaxDate { get; set; }
        public string InsuranceNo { get; set; }
        public DateTime? InsDate { get; set; }
        public string PolutionNo { get; set; }
        public DateTime? PolExpDate { get; set; }
        public string RCBookNo { get; set; }
        public DateTime? RCExpDate { get; set; }
        public int CompanyVechile { get; set; }
        public string OwnerPhoneNo { get; set; }
        public string HomeLandmark { get; set; }
        public string ModelYear { get; set; }
        public string DayOnly { get; set; }
        public string VechMobileNo { get; set; }
        public DateTime? EntryDate { get; set; }
        public string NewEntry { get; set; }
        public string VehicleModelId { get; set; }
        public string ServiceTypeId { get; set; }
        public string VehicleGroupId { get; set; }
        public int BookingNo { get; set; }
        public DateTime? ReqDate { get; set; }
        public DateTime? ReqTime { get; set; }
        public DateTime? CallTime { get; set; }
        public string CustomerName { get; set; }
        public string CusID { get; set; }
        public string PhoneNo { get; set; }
        public string AltPhoneNo { get; set; }
        public string PickupAddress { get; set; }
        public string LandMark { get; set; }
        public string PickupPlace { get; set; }
        public string DropPlace { get; set; }
        public string Package { get; set; }
        public string VehicleType { get; set; }
        public int NoofVehicle { get; set; }
        public int VechID { get; set; }
        public string DriverName { get; set; }
        public string PresentDriverLandMark { get; set; }
        public string ExecutiveName { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? EffectiveTill { get; set; }
        public int DriverId { get; set; }

    }
    public class UsersGroup
    {

        //public UsersGroup[] U = null;
        public List<UsersGroup> U { get; set; }
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string MiddleName { set; get; }
        public string EmpNo { set; get; }
        public string Email { set; get; }
        public string ContactNo1 { set; get; }
        public string ContactNo2 { set; get; }
        public int? mgrId { set; get; }
        public int ManagerName { set; get; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public int StateId { set; get; }
        public int CountryId { set; get; }
        public int Active { get; set; }
        public int GenderId { get; set; }
        public string UserType { set; get; }
        public int UserTypeId { set; get; }
        public string Address { set; get; }
        public string AltAdress { set; get; }
        public string Photo { get; set; }
        public string Role { set; get; }
        public int RoleId { set; get; }
        public DateTime? RFromDate { get; set; }
        public DateTime? RToDate { get; set; }
        public string DUserName { get; set; }
        public string DPassword { get; set; }
        public string WUserName { get; set; }
        public string WPassword { get; set; }
        public string insupdflag { get; set; }
        public int cmpId { set; get; }
        public string Company { set; get; }

    }
    public class CompanyRoles
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string RoleId { get; set; }
        public string Active { get; set; }
        public string IsPublic { get; set; }
        public string Company { get; set; }
        public int CompanyId { get; set; }
        public int insdelflag { get; set; }

    }
    public class PaymentReceivings
    {
        public int amount { get; set; }

        public string code { get; set; }

        public string date { get; set; }

        public int desc { get; set; }

        public int Id { get; set; }

        public int inventoryId { get; set; }

        public int quantity { get; set; }

        public string receivedOn { get; set; }

        public int transactionId { get; set; }

        public string transactiontype { get; set; }

    }
    public class InventoryReceivings
    {
        public int amount { get; set; }

        public string code { get; set; }

        public string date { get; set; }

        public int Id { get; set; }

        public int inventoryId { get; set; }

        public int quantity { get; set; }

        public string reason { get; set; }

        public int refundamt { get; set; }

        public string returnedOn { get; set; }

        public int transactionId { get; set; }

        public string transactiontype { get; set; }

    }

    public class TroubleTicketingDetails
    {
        //public int Id { get; set; }
        public int RefId { get; set; }

        public int Type { get; set; }

        public int createdBy { get; set; }

        public int Raised { get; set; }

        public int TicketTitle { get; set; }

        public string IssueDetails { get; set; }

        public string AddInfo { get; set; }

        public int Status { get; set; }

        public int Asign { get; set; }



    }
    public class TroubleTicketingHandlers
    {
        public int handledOn { get; set; }

        public int Id { get; set; }

        public int status { get; set; }

        public int TTId { get; set; }

        public int userid { get; set; }

    }

    public class TroubleTicketingDevice
    {
        public int deviceid { get; set; }

        public int Id { get; set; }

        public int ticketTypeId { get; set; }

        public int TTId { get; set; }
    }

    public class SMSEmailSubscribers
    {
        public int AlertId { get; set; }

        public string emailid { get; set; }

        public DateTime enddate { get; set; }

        public int frequency { get; set; }

        public int Id { get; set; }

        public string phNo { get; set; }

        public DateTime startdate { get; set; }

        public int userid { get; set; }
    }

    public class SMSGatewayConfiguration
    {
        public int Id { get; set; }

        public DateTime enddate { get; set; }

        public string hashkey { get; set; }


        public string providername { get; set; }

        public string pwd { get; set; }

        public string saltkey { get; set; }

        public DateTime startdate { get; set; }

        public string username { get; set; }
        public string ClientId { get; set; }
        public string SecretId { get; set; }
        public string insupdflag { get; set; }
    }

    public class PaymentGatewaySettings
    {
        public int Id { get; set; }
        public DateTime enddate { get; set; }

        public string hashkey { get; set; }

        public string ClientId { get; set; }

        public string secretId { get; set; }

        public int PaymentGatewayTypeId { get; set; }

        public string providername { get; set; }

        public string pwd { get; set; }

        public string saltkey { get; set; }

        public DateTime startdate { get; set; }

        public string username { get; set; }
        public string insupdflag { get; set; }

    }

    public class Transactions
    {
        public int Id { get; set; }

        public string barcode { get; set; }

        public string BTPOSid { get; set; }

        public string busNumber { get; set; }

        public int busId { get; set; }

        public string change { get; set; }

        public string company { get; set; }

        public string companyId { get; set; }

        public string ConductorId { get; set; }

        public string ConductorName { get; set; }

        public DateTime Date { get; set; }

        public string destination { get; set; }

        public string fare { get; set; }

        public string greetingMessage { get; set; }

        public string luggageType { get; set; }

        public string passengerType { get; set; }

        public string passengerId { get; set; }

        public string paymentId { get; set; }

        public string printdataId { get; set; }

        public string route { get; set; }

        public string routecode { get; set; }

        public string routeId { get; set; }

        public string source { get; set; }

        public DateTime time { get; set; }

        public string ticketHolderId { get; set; }

        public string ticketHolderName { get; set; }

        public string TicketNumber { get; set; }

        public string ticketValidityPeriod { get; set; }

        public int totalamount { get; set; }

        public int amountpaid { get; set; }

        public string TransactionCode { get; set; }

        public string TransactionId { get; set; }

        public string transactionType { get; set; }

        public int userid { get; set; }

        public string ChangeRendered { get; set; }

    }
    public class RegistrationBTPOS
    {
        public string code { get; set; }

        public string uniqueId { get; set; }

        public string ipconfig { get; set; }

        public string RegeneratedNo { get; set; }

        public int Active { get; set; }
    }

    public class loginpage
    {
        public string userid { get; set; }

        public string password { get; set; }
    }
    public class TicketGeneration
    {
        public string Source { get; set; }
        public string Target { get; set; }
        public int NoOfTickets { get; set; }
    }

    public class BOTPOSL
    {
        public int Id { set; get; }
        public int BTPOSid { set; get; }
        public int licenseId { set; get; }
        public DateTime FromDate { set; get; }
        public DateTime EndDate { set; get; }
        public DateTime NotificationDate { set; get; }
        public int TransactionId { set; get; }
        public DateTime RenewedOn { set; get; }
    }
    public class FleetOL
    {
        public int Id { set; get; }
        public int FleetOwnerId { set; get; }
        public int LicenseId { set; get; }
        public int Code { set; get; }
        public DateTime FromDate { set; get; }
        public DateTime EndDate { set; get; }
        public DateTime NotificationDate { set; get; }
        public int TransactionId { set; get; }
        public DateTime RenewedOn { set; get; }
    }
    public class Payment
    {
        public int Id { set; get; }
        public int PaymentTypeId { set; get; }
        public int Amount { set; get; }
        public DateTime date { set; get; }
        public int TransactionId { set; get; }
    }
    public class Smsformat
    {
        public int Id { set; get; }
        public string message { set; get; }
        public int Active { set; get; }
        public string Desc1 { set; get; }
        public string fromaddr { set; get; }
        public string ToAddr { set; get; }
        public int BTPOSGrpId { set; get; }
    }
    public class Gmailformat
    {
        public int Id { set; get; }
        public string message { set; get; }
        public int Active { set; get; }
        public string Desc1 { set; get; }
        public string Fromaddr { set; get; }
        public string Toaddrs { set; get; }
        public int BTPOSGrpId { set; get; }
    }
    public class BTPOSOPRTR
    {
        public int Id { set; get; }
        public int BTPOSId { set; get; }
        public int Userid { set; get; }
        public int Active { set; get; }
    }
    public class BTPOSLoc
    {
        public int Id { set; get; }
        public int BTPOSid { set; get; }
        public int Xcord { set; get; }
        public int Ycord { set; get; }
        public TimeSpan time { set; get; }
        public DateTime date { set; get; }

    }
    public class Address
    {
        public int Id { set; get; }
        public int cityid { set; get; }
        public int stateid { set; get; }
        public int countryid { set; get; }
        public string street1 { set; get; }
        public string street2 { set; get; }
        public int zipcodeid { set; get; }
        public string City { set; get; }
        public string country { set; get; }
        public string State { set; get; }
        public string zipcode { set; get; }
    }
    public class SMSEmailSettings
    {
        public int AlertTypeId { set; get; }
        public string fromaddress { set; get; }
        public int Id { set; get; }
        public string smsemailtext { set; get; }
        public string toaddres { set; get; }
    }
    public class PrinterData
    {
        public int BtPOSidId { set; get; }
        public int Id { set; get; }
        public string ipconfig { set; get; }
        public string printeddata { set; get; }
        public string transactionId { set; get; }
    }
    public class SecurityLog
    {
        public int Id { set; get; }
        public string logdata { set; get; }
        public DateTime logedon { set; get; }
        public string source { set; get; }
    }
    public class ReportsFields
    {
        public string fieldName { set; get; }
        public int Id { set; get; }
        public string ReportTypeId { set; get; }
    }
    public class SystemLog
    {
        public int Id { set; get; }
        public string logdata { set; get; }
        public DateTime logedon { set; get; }
        public string source { set; get; }
    }
    public class UserLog
    {
        public int Id { set; get; }
        public string logdata { set; get; }
        public DateTime logedon { set; get; }
        public string source { set; get; }
        public int userid { set; get; }
    }
    public class ErrorCodes
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string Desc1 { set; get; }
        public string ErrrorCode { set; get; }
        public int Typegrpid { set; get; }
    }
    public class ReportsTypes
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string Desc1 { set; get; }
        public string ReportType { set; get; }
        public int Typegrpid { set; get; }
    }
   
    public class ExpensesClass
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string ExpenseType { set; get; }
        public string Desc1 { set; get; }
        public int Typegrpid { set; get; }
    }
    public class NOCBtPosStatus
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string NOCBtPostatus { set; get; }
        public string Desc1 { set; get; }
        public int Typegrpid { set; get; }
    }
    public class CardTypes
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string Cardtype { set; get; }
        public string Desc1 { set; get; }
        public int Typegrpid { set; get; }
    }

    public class Types1
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string GroupName { set; get; }
        public string Desc1 { set; get; }
        public int Key1 { set; get; }
        public string Name { set; get; }
        public int Typegrpid { set; get; }
        public string Value { set; get; }
    }
    public class RouteType
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string Routetype { set; get; }
        public string Desc1 { set; get; }
        public int Typegrpid { set; get; }
    }
    public class AccessType
    {
        public int Id { set; get; }
        public int Active { set; get; }
        public string Accesstype { set; get; }
        public string Desc1 { set; get; }
        public int Typegrpid { set; get; }
    }
    public class LicenseKeyFile
    {
        public int Id { set; get; }
        public int BTPOSid { set; get; }
        public string EncrptyKey1 { set; get; }
        public string EncrptyKey2 { set; get; }
        public string keyfilename { set; get; }
    }
    public class FirmwareDetails
    {
        public int Id { set; get; }
        public int BTPOSid { set; get; }
        public string Desc1 { set; get; }
        public string FirmwareVersion { set; get; }
        public string Ipconfig { set; get; }
    }
    public class Users
    {
        public List<Users> list1 { get; set; }
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string MiddleName { set; get; }
        public string EmpNo { set; get; }
        public string Email { set; get; }
        public string ContactNo1 { set; get; }
        public string ContactNo2 { set; get; }
        public int? mgrId { set; get; }
        public int ManagerName { set; get; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public int StateId { set; get; }
        public int CountryId { set; get; }
        public int Active { get; set; }
        public int GenderId { get; set; }
        public string UserType { set; get; }
        public int UserTypeId { set; get; }      
        public string Address { set; get; }
        public string AltAdress { set; get; }
        public string Photo { get; set; }             
        public string Role { set; get; }
        public int RoleId { set; get; }
        public DateTime? RFromDate { get; set; }
        public DateTime? RToDate { get; set; }
        public string DUserName { get; set; }
        public string DPassword { get; set; }
        public string WUserName { get; set; }
        public string WPassword { get; set; }
        public string insupdflag { get; set; }
        public int companyId { set; get; }
        public string Company { set; get; }
     
    }

    public class Register
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Emailaddress { get; set; }
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
    }

    public class login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int result { get; set; }
    }
    public class stops
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int Active { get; set; }
        public string insupdflag { get; set; }
    }
    public class Objects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ParentId { get; set; }

        public int RootObjectId { get; set; }

        public string Path { get; set; }
        public int Active { get; set; }
        public string insupdflag { get; set; }

    }
    public class ObjectAccess
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int ObjectId { get; set; }

        public int AccessId { get; set; }
    }
    public class RouteDetails
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public decimal DistanceFromSource { get; set; }
        public decimal DistanceFromDestination { get; set; }
        public decimal DistanceFromPreviousStop { get; set; }
        public decimal DistanceFromNextStop { get; set; }
        public int PreviousStopId { get; set; }
        public int NextStopId { get; set; }
        public String StopName { get; set; }
        public String StopCode { get; set; }
        public int stopId { get; set; }
        public String prevstop { get; set; }
        public String nextstop { get; set; }
        public int StopNo { get; set; }
        public String insupddelflag { get; set; }
        public int FleetOwnerId { get; set; }

    }
    public class ISales
    {
        public int Id { get; set; }
        public String ItemName { get; set; }
        public int Quantity { get; set; }

        public int PerUnitPrice { get; set; }
        public String PurchaseDate { get; set; }
        public int InVoiceNumber { get; set; }
    }
    public class IPurchases
    {
        public int Id { get; set; }
        public String ItemName { get; set; }
        public String ItemCode { get; set; }
        public int Quantity { get; set; }

        public int PerUnitPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public int subCategoryId { get; set; }

        public string subCategory { get; set; }
        public int ItemTypeId { get; set; }
    }
    public class InventoryItem
    {
        public int Id { get; set; }
        public String ItemName { get; set; }
        // public String ItemImage { get; set; }
        public String Code { get; set; }
        public String Description { get; set; }
        public String Category { get; set; }
        public String SubCategory { get; set; }
        public int ReOrderPoint { get; set; }
        public string ItemImage { get; set; }
        public decimal price { get; set; }
        public string Itemmodel { get; set; }
        public string features { get; set; }
       
    }

    public class FleetOwnerRequest
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String MobileNo { get; set; }
        public String CompanyName { get; set; }
        public String Description { get; set; }
        public string insupdflag { get; set; }
    }

    public class RouteFare
    {
        public int Id { get; set; }

        public int RouteId { get; set; }
        public string VehicleType { get; set; }


        public int SourceStopId { get; set; }
        public int DestinationStopId { get; set; }
        public string Distance { get; set; }
        public int PerUnitPrice { get; set; }

        public int Amount { get; set; }

        public String FareType { get; set; }
        public int Active { get; set; }
    }
    public class FleetownerRoute
    {
        public int Id { get; set; }
        public int FleetOwnerId { get; set; }

        public int CompanyId { get; set; }

        public int RouteId { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
        public int Active { get; set; }
        public string insupddelflag { get; set; }
    }
    public class FleetOwnerRouteStop
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int FleetOwnerId { get; set; }

        public int StopId { get; set; }

        public int StopNo { get; set; }
        public String PreviousStop { get; set; }
        public String NextStop { get; set; }

        public int Active { get; set; }
    }

    public class FORouteFareConfig
    {

        public List<FORouteFare> routeFare { get; set; }
        public int Id { get; set; }
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string RouteCode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public int VehicleId { get; set; }
        public string VehicleRegNo { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string insupddelflag { get; set; }
        public string PriceType { get; set; }
        public int PriceTypeId { get; set; }

        public int SourceId { get; set; }
        public string Source { get; set; }
        public int DestinationId { get; set; }
        public string Destination { get; set; }
    }

    public class FORouteFare
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public string VehicleTypeId { get; set; }
        public int FromStopId { get; set; }
        public int ToStopId { get; set; }
        public decimal Distance { get; set; }
        public decimal PerUnitPrice { get; set; }
        public decimal Amount { get; set; }
        public String FareType { get; set; }
        public int FareTypeId { get; set; }
        public int VehicleId { get; set; }
        public int Active { get; set; }
        public int FleetOwnerId { get; set; }
        public int CompanyId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string insupddelflag { get; set; }

        public string PricingType { get; set; }

        public Decimal PerkmPrice { get; set; }
    }

    public class LicenseDetails
    {
        public int Id { get; set; }
        public int LicenseTypeId { get; set; }
        public int LicenseCatId { get; set; }
        public int FeatureTypeId { get; set; }
        public string FeatureName { get; set; }
        public String FeatureLabel { get; set; }
        public String LicenseCode { get; set; }
        public String LicenseName { get; set; }
        public String FeatureValue { get; set; }
        public String LabelClass { get; set; }
        public int Active { get; set; }        
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public string insupddelflag { get; set; }
       public int LicenseTypeGroupId { get; set; }
    }

    public class LicensePricing
    {
        public int LicenseId { get; set; }
        public String RenewalFreqType { get; set; }
        public int RenewalFreqTypeId { get; set; }
        public int RenewalFreqUnit { get; set; }
        public string RenewalFreq { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime? fromdate { get; set; }
        public DateTime? todate { get; set; }
        public int Id { get; set; }

        public int categoryid { get; set; }
        public int Active { get; set; }
        public string insupddelflag { get; set; }
    }

    public class FleetDetails
    {
        public int VehicleLayoutId;
        public string VehicleLayout;
        public int Id { get; set; }

        public string VehicleRegNo { get; set; }
        public int VehicleTypeId { get; set; }

        public String FleetOwnerId { get; set; }
        public String CompanyId { get; set; }
        public String ServiceTypeId { get; set; }

        public int Active { get; set; }

        public String EngineNo { get; set; }

        public String FuelUsed { get; set; }

        public DateTime? MonthAndYrOfMfr { get; set; }

        public string ChasisNo { get; set; }

        public int SeatingCapacity { get; set; }

        public DateTime? DateOfRegistration { get; set; }
        public string insupddelflag { get; set; }

    }
    public class FleetRoutes
    {
        public int Id { get; set; }
        public string VehicleRegNo { get; set; }
        public string RouteName { get; set; }
        public string RouteCode { get; set; }
        public int VehicleId { get; set; }
        public int RouteId { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTill { get; set; }
        public int Active { get; set; }
        public int cmpId { get; set; }
        public int fleetownerId { get; set; }
        public string insupddelflag { get; set; }
    }
    public class FleetAvailability
    {
        public int Id { get; set; }
        public string VehicleRegNo { get; set; }
        public int VehicleId { get; set; }
        public string FleetOwner { get; set; }
        public int fleetOwnerId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string insupddelflag { get; set; }
    }

    public class FleetStaff
    {
        public int Id { get; set; }
        public int cmpId { get; set; }
        public int roleId { get; set; }
        public int vehicleId { get; set; }

        public int UserId { get; set; }

        public int RoleName { get; set; }
        public int Company { get; set; }

        public string VechileRegNo { get; set; }
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int Active { get; set; }
        public string insupddelflag { get; set; }
    }

    public class FleetBTPOS
    {
        public int Id { get; set; }
        public int cmpId { get; set; }
        public int posId { get; set; }
        public int vehicleId { get; set; }

        public int fleetOwnerId { get; set; }

        public string BTPOSId { get; set; }

        public string VechileRegNo { get; set; }
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string insupddelflag { get; set; }
    }

    public class ConfigData
    {
        public int includeStatus { get; set; }
        public int includeCategories { get; set; }
        public int includeLicenseCategories { get; set; }
        public int includeVehicleGroup { get; set; }
        public int includeGender { get; set; }
        public int includeFrequency { get; set; }
        public int includePricingType { get; set; }
        public int includeTransactionType { get; set; }
        public int includeApplicability { get; set; }
        public int includeFeeCategory { get; set; }
        public int includeTransChargeType { get; set; }
        public int includeVehicleType { get; set; }
        public int includeVehicleModel { get; set; }
        public int includeVehicleMake { get; set; }
        public int includeDocumentType { get; set; }
        public int includePaymentType { get; set; }
        public int includeMiscellaneousTypes { get; set; }
        public int includeCardCategories { get; set; }
        public int includeCardTypes { get; set; }
        public int includeVehicleLayoutType { get; set; }
        public int includeLicenseFeatures { get; set; }
        public int includeCardModels { get; set; }
        public int includeCards { get; set; }
        public int includeTransactions { get; set; }
        public int includeCountry { get; set; }
        public int includeActiveCountry { get; set; }
        public int includeFleetOwner { get; set; }
        public int includeUserType { get; set; }
    }
    public class VehicleConfig
    {
        public int? needFleetDetails { get; set; }
        public int? needRoutes { get; set; }
        public int? needRoles { get; set; }
        public int? needusers { get; set; }
        public int? needfleetowners { get; set; }
        public int? needvehicleType { get; set; }
        public int? needvehicleRegno { get; set; }
        public int? needServiceType { get; set; }
        public int? needCompanyName { get; set; }
        public int? needVehicleLayout { get; set; }
        public int? needFleetRoute { get; set; }
        public int? needRouteName { get; set; }
        public int? needHireVehicle { get; set; }
        public int? needbtpos { get; set; }
        public int? cmpId { get; set; }
        public int? fleetownerId { get; set; }
        public int? needfleetownerroutes { get; set; }
        public int? needvehicleMake { get; set; }
        public int? needVehicleGroup { get; set; }

        public int? needDocuments { get; set; }


    }

    public class LicenseTypes
    {
        public int Id { set; get; }
        public string LicenseType { set; get; }
        public string LicenseCode { set; get; }
        public int LicenseCategoryId { set; get; }
        public int Active { set; get; }        
        public string Desc { set; get; }
        public string LicenseCategory { set; get; }
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public int LicenseId { get; set; }
         public int LicensePricingId { get; set; }
        public String RenewalFreqType { get; set; }
        public int RenewalFreqTypeId { get; set; }
        public int RenewalFreqUnit { get; set; }
        public string RenewalFreq { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime? Pfromdate { get; set; }
        public DateTime? Ptodate { get; set; }
       
        public int PActive { get; set; }
        public string insupddelflag { get; set; }

        //license pos      
	    public int LPOSId { get; set; }
         public int BTPOSTypeId { get; set; }
         public int NoOfUnits { get; set; }
	    public string POSType { get; set; }
        public String POSLabel { get; set; }
        public String POSLabelClass { get; set; }	
        public DateTime? POSfromdate { get; set; }
        public DateTime? POStodate { get; set; }       
        public int POSActive { get; set; }

        public List<LicenseDetails> licenseDetails { get; set; }
    }
               
    public class LicenseTypes1
    {
       // public List<licenses> lltypes { get; set; }
        public int Id { set; get; }
        public int Active { set; get; }
        public string LicenseType { set; get; }
        public string Desc { set; get; }
        public string LicenseCategory { set; get; }
        public int LicenseCategoryId { set; get; }
        public int LicenseId { set; get; }
        public int RenewalFreqTypeId { set; get; }

        public int RenewalFreq { set; get; }
        public Decimal UnitPrice { set; get; }
        public DateTime fromdate { set; get; }

        public DateTime todate { set; get; }

        public char insupddelflag { set; get; }
        public string FeatureName { set; get; }
        public string FeatureLabel { set; get; }
        public string FeatureValue { set; get; }
    }
    public class licenses
    {
        public int LicenseId { set; get; }
        public int RenewalFreqTypeId { set; get; }

        public int RenewalFreq { set; get; }
        public Decimal UnitPrice { set; get; }
        public DateTime fromdate { set; get; }

        public DateTime todate { set; get; }        

        public char insupddelflag { set; get; }
        public string Featurename { set; get; }
        public string Featurelabel { set; get; }
        public string Featurevalue { set; get; }
    }
    public class Inventory
    {
        public int Active { set; get; }
        public int availableQty { set; get; }
        public string category { set; get; }
        public string code { set; get; }
        public string desc { set; get; }
        public int InventoryId { set; get; }
        public string name { set; get; }
        public int PerUnitPrice { set; get; }
        public int reorderpoint { set; get; }
        public string subcat { set; get; }
    }
    public class PurchaseOrder
    {
        public int Id { set; get; }
        public string PONum { set; get; }
        public int TranscationId { set; get; }
        public DateTime? Date { set; get; }
        public decimal amount { set; get; }
        public int itemId { set; get; }
        public decimal Quantity { set; get; }
        public int StatusId { set; get; }
    }
    public class VehicleLayout
    {
        //public int Id { get; set; }
        public int VehicleLayoutTypeId { get; set; }
        public int RowNo { get; set; }
        public int ColNo { get; set; }
        public int VehicleTypeId { get; set; }
        public String label { get; set; }
        public string insupdflag { get; set; }
        //public int FleetOwnerId { get; set; }
    }
    public class FleetOwnerVehicleLayout
    {
        public int VehicleLayoutTypeId { get; set; }
        public int RowNo { get; set; }
        public int ColNo { get; set; }
        public int VehicleTypeId { get; set; }
        public String label { get; set; }
        public string insupdflag { get; set; }
        public int FleetOwnerId { get; set; }
    }
    public class reset
    {

        public string UserName { set; get; }
        public string OldPassword { set; get; }
        public string NewPassword { set; get; }
        public string ReenterNewPassword { set; get; }
        public string Pwd { get; set; }

    }
    public class FORouteFleetSchedule
    {
        // public int Id { get; set; }
        public List<VehicleSchedule> VSchedule { get; set; }
        public int VehicleId { get; set; }
        public int RouteId { get; set; }
        public int FleetOwnerId { get; set; }
        public string insupddelflag { get; set; }
    }

    public class VehicleSchedule
    {
        public string StopName { get; set; }
        public string StopCode { get; set; }
        public string StopNo { get; set; }
        public int StopId { get; set; }
        public int ArrivalHr { get; set; }
        public int DepartureHr { get; set; }
        public decimal? Duration { get; set; }
        public int ArrivalMin { get; set; }
        public int DepartureMin { get; set; }
        public string ArrivalAMPM { get; set; }
        public string DepartureAmPm { get; set; }
        public DateTime arrivaltime { get; set; }
        public DateTime departuretime { get; set; }
        public string insupddelflag { get; set; }
    }

    public class ShoppingCart
    {
        public int Id { get; set; }
        public string ItemName { set; get; }
        public decimal UnitPrice { set; get; }
        public int ItemId { set; get; }

        // public string insupddelflag { set; get; }

    }
    public class BTPOSMoitoringPage
    {
        public int BTPOSId { get; set; }
        public float Xcoordinate { get; set; }
        public float Ycoordinate { get; set; }
        public string LocationName { get; set; }
        public int SNo { get; set; }
        public DateTime DateTime { get; set; }

    }
    public class Shoppingcarts
    {

        public List<itemslist> slist { get; set; }
        public int Item { get; set; }
        public int Id { get; set; }

        public String SalesOrderNum { get; set; }


        public int TransactionId { get; set; }

        public DateTime? Date { get; set; }
        public Decimal amount { get; set; }

        public Decimal Quantity { get; set; }
        public int Status { get; set; }
        //  public int Transactionstatus { get; set; }
        //  public String Gateway_transId { get; set; }
        //  public int PaymentMode { get; set; }
        //   public String Transaction_Num { get; set; }




    }

    public class itemslist
    {
        public int TransactionId { get; set; }
        public String Transaction_Num { get; set; }

        public Decimal amount { get; set; }

        public int PaymentMode { get; set; }

        public DateTime? Date { get; set; }

        public int Transactionstatus { get; set; }
        public String Gateway_transId { get; set; }


    }
    public class EmailGatewaySettings
    {
        public int Id { get; set; }
        public DateTime enddate { get; set; }

        public string hashkey { get; set; }


        public string providername { get; set; }

        public string pwd { get; set; }

        public string saltkey { get; set; }

        public DateTime startdate { get; set; }

        public string username { get; set; }
        public string ClientId { get; set; }
        public string SecretId { get; set; }

        public int Port { get; set; }
        public string insupdflag { get; set; }

    }

    public class Registrationform
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Emailaddress { get; set; }
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
    }

    public class BTPOSTrans
    {
        public string BTPOSId { get; set; }
        public int transTypeId { get; set; }
        public Decimal amt { get; set; }
        public string gatewayId { get; set; }
        public string datetime { get; set; }
        public string srcId { get; set; }
        public string destId { get; set; }
    }
    public class UploadDataModel
    {
        public string testString1 { get; set; }
        public string testString2 { get; set; }
    }

    public class Sblocklist
    {
        //public int Id { get; set; }

        public int ItemName { get; set; }
        public string Reason { get; set; }
        public string insupddelflag { get; set; }
    }

    //public class LicenseConfigDetails {
    //    public int Id { get; set; }
    //    public int FeatureTypeId { get; set; }
    //    public string FeatureName { get; set; }
    //    public String FeatureLabel { get; set; }
    //    public String LicenseCode { get; set; }
    //    public String LicenseName { get; set; }
    //    public String FeatureValue { get; set; }
    //    public String LabelClass { get; set; }

    //    public int Active { get; set; }
    //    public int LicenseTypeId { get; set; }
    //    public int LicenseCatId { get; set; }
    //    public DateTime? fromDate { get; set; }
    //    public DateTime? toDate { get; set; }
    //    public string insupddelflag { get; set; }

    //    public int LicenseId { get; set; }
    //    public String RenewalFreqType { get; set; }
    //    public int RenewalFreqTypeId { get; set; }
    //    public int RenewalFreqUnit { get; set; }
    //    public string RenewalFreq { get; set; }
    //    public decimal UnitPrice { get; set; }
    //    public DateTime? fromdate { get; set; }
    //    public DateTime? todate { get; set; }
    //    public int Id { get; set; }

    //    public int categoryid { get; set; }
    //    public int Active { get; set; }
    //    public string insupddelflag { get; set; }
    //}
   
    public class faqs 
    {

        public string flag { get; set; }
        public int Id { get; set; }
        public string Question { get; set; }

        public string Answer { get; set; }
        public string CreatedBy { get; set; }
        public int AppType { get; set; }
        public int Category { get; set; }
        public int SubCategory { get; set; }
        public int active { get; set; }
        public int category { get; set; }

    }

    public class Userdetails
    {
        public string flag { get; set; }
        public int Id { get; set; }
        public string username { get; set; }
        public string Accountnumber { get; set; }
        public string balance { get; set; }
        public string expirydate { get; set; }
        public string startdate { get; set; }
        public string status { get; set; }

    }
    public class driverdetails
    {
        public string flag { get; set; }
        public int DId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public string PAddress { get; set; }
        public string PCity { get; set; }
        public string PPin { get; set; }
        public float OffMobileNo { get; set; }
        public string PMobNo { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string BloodGroup { get; set; }
        public string LicenceNo { get; set; }
        public DateTime LiCExpDate { get; set; }
        public string BadgeNo { get; set; }
        public DateTime BadgeExpDate { get; set; }
        public string Remarks { get; set; }
        public string Photo { get; set; }
        public string licenseimage { get; set; }
        public string badgeimage { get; set; }
        public string DriverCode { get; set; }
        
    }
    public class vehiclemas
    { 
        public string flag { get; set; }
        public int Id { get; set; }
        public int VID { get; set; }
        public int CompanyId { get; set; }
        public int OwnerId { get; set; }
        public int VehicleTypeId { get; set; }
        public string RegistrationNo { get; set; }
        public int HasAC { get; set; }
        public int StatusId { get; set; }
        public int IsVerified { get; set; }
        public string VehicleCode { get; set; }
        public string Type { get; set; }
        public string OwnerName { get; set; }
        public string ChasisNo { get; set; }
        public string Engineno { get; set; }      
        public float RoadNo { get; set; }
        public DateTime RoadTaxDate { get; set; }
        public string InsuranceNo { get; set; }
        public DateTime InsDate { get; set; }
        public string PolutionNo { get; set; }
        public DateTime PolExpDate { get; set; }
        public string RCBookNo { get; set; }
        public DateTime RCExpDate { get; set; }
        public int CompanyVechile { get; set; }
        public string OwnerPhoneNo { get; set; }
        public string HomeLandmark { get; set; }
        public string ModelYear { get; set; }
        public string DayOnly { get; set; }       
        public string VechMobileNo { get; set; }
        public DateTime EntryDate { get; set; }
        public string NewEntry { get; set; }
        public int VehicleModelId { get; set; }   
        public int ServiceTypeId { get; set; }
        public int VehicleGroupId { get; set; }
        public string photo { get; set; }
        public string Status { get; set; }
        public string Fleetcode { get; set; }
        public int isDriverOwned { get; set; }
        public int VehicleMakeId { get; set; }
    }
    public class allocatedriver
    {
        public string flag { get; set; }
        public int Id { get; set; }


        public int CompanyId { get; set; }
        public int BookingNo { get; set; }

        public string CustomerName { get; set; }
        public string CusID { get; set; }
        public string PhoneNo { get; set; }
        public string AltPhoneNo { get; set; }
        public string Address { get; set; }
        public string PickupAddress { get; set; }
        public string LandMark { get; set; }
        public string PickupPlace { get; set; }
        public string DropPlace { get; set; }
        public string Package { get; set; }
        public string VehicleType { get; set; }
        public int NoofVehicle { get; set; }
        public int VechID { get; set; }
        public string RegistrationNo { get; set; }
        public string DriverName { get; set; }
        public int DriverId { get; set; }
        public string PresentDriverLandMark { get; set; }
        public string ExecutiveName { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime EffectiveTill { get; set; }
        public string VehicleModelId { get; set; }
        public string ServiceTypeId { get; set; }
        public string VehicleGroupId { get; set; }
    }
    public class UserLocation
    {
        public string flag { get; set; }

        public int BNo { get; set; }
        public string BookingType { get; set; }

        public string ReqVehicle { get; set; }
        public string Customername { get; set; }
        public string CusID { get; set; }
        public string PhoneNo { get; set; }
        public string AltPhoneNo { get; set; }
        public string CAddress { get; set; }
        public string PickupAddress { get; set; }
        public string LandMark { get; set; }
        public string Package { get; set; }
        public string PickupPalce { get; set; }
        public string DropPalce { get; set; }
        public string ReqType { get; set; }
        public int ExtraCharge { get; set; }
        public int NoofVehicle { get; set; }
        public string ExecutiveName { get; set; }
        public int VID { get; set; }
        public string BookingStatus { get; set; }
        public string CustomerSMS { get; set; }
        public string CancelReason { get; set; }
        public decimal CBNo { get; set; }
        public string ModifiedBy { get; set; }
        public string CancelBy { get; set; }
        public string ReconfirmedBy { get; set; }
        public string AssignedBy { get; set; }

        public float lat { get; set; }
        public float lng { get; set; }

        public object Mobileotp { get; set; }
    }
    public class cancel
    {
        public int BNo { get; set; }

        public string BookingStatus { get; set; }

        public string CancelReason { get; set; }

        public string CancelBy { get; set; }

    }
    public class UserAccount
    {

        public string flag { get; set; }
        public int id { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string Mobilenumber { get; set; }
        public string Password { get; set; }
        public String EVerificationCode { get; set; }
        public DateTime EVerifiedOn { get; set; }
        public int IsEmailVerified { get; set; }
        public String MVerificationCode { get; set; }
        public string Passwordotp { get; set; }
        public DateTime MVerifiedOn { get; set; }
        public int IsMobileVerified { get; set; }

        public DateTime CreatedOn { get; set; }
        public int ENoOfAttempts { get; set; }
        public int MNoOfAttempts { get; set; }
        public string Firstname { get; set; }
        public string lastname { get; set; }
        public int AuthTypeId { get; set; }
        public string AltPhonenumber { get; set; }
        public string Altemail { get; set; }
        public string AccountNo { get; set; }
        public string NewPassword { get; set; }
        public object Mobileotp { get; set; }

        public object Emailotp { get; set; }
    }
    public class DriverAccount
    {

        public string flag { get; set; }
        public int id { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string Mobilenumber { get; set; }
        public string Password { get; set; }
        public String EVerificationCode { get; set; }
        public DateTime EVerifiedOn { get; set; }
        public int IsEmailVerified { get; set; }
        public String MVerificationCode { get; set; }
        public string Passwordotp { get; set; }
        public DateTime MVerifiedOn { get; set; }
        public int IsMobileVerified { get; set; }

        public DateTime CreatedOn { get; set; }
        public int ENoOfAttempts { get; set; }
        public int MNoOfAttempts { get; set; }
        public string Firstname { get; set; }
        public string lastname { get; set; }
        public int AuthTypeId { get; set; }
        public string AltPhonenumber { get; set; }
        public string Altemail { get; set; }
        public string AccountNo { get; set; }
        public string NewPassword { get; set; }
        public object Mobileotp { get; set; }

        public object Emailotp { get; set; }
    }
    public class passenger
    {
        public string Fname { get; set; }

        public string Lname { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public string datetime { get; set; }
        public int Pnr_Id { get; set; }
        public string Pnr_No { get; set; }
        public int Identityproof { get; set; }
    }
    public class book
    {
        public string flag { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string src { get; set; }
        public string dest { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Blocked { get; set; }


    }
    public class travels
    {
        public string flag { get; set; }
        public int SlNo { get; set; }



        public int VechID { get; set; }
        public string RegistrationNo { get; set; }
        public string DriverName { get; set; }
        public string PartyName { get; set; }
        public string PickupPlace { get; set; }
        public string DropPlace { get; set; }
        public int StartMeter { get; set; }

        public string ExecutiveName { get; set; }
        public decimal BookingNo { get; set; }

        public string CloseStatus { get; set; }
    }
    public class HVUsers
    {
        public int Id { get; set; }

        public int userid { get; set; }
        public string email { get; set; }
        public string Address { get; set; }
        public int Accountid { get; set; }
        public int preferenceTypeId { get; set; }
        public int preferenceId { get; set; }
        public string flag { get; set; }
    }
   
    public class close
    {
        public string flag { get; set; }
        public int SlNo{get;set;} 
        public DateTime EntryDate{get;set;} 
        public int VechID {get;set;} 
        public String RegistrationNo {get;set;}  
        public String DriverName{get;set;} 
        public String PartyName{get;set;} 
        public String PickupPlace{get;set;} 
        public String DropPlace{get;set;} 
        public int StartMeter{get;set;} 
         public int EndMeter{get;set;} 
         public int OtherExp{get;set;} 
         public int GeneratedAmount{get;set;} 
        public int ActualAmount{get;set;}
        public string ExecutiveName{get;set;} 
        public Decimal BNo{get;set;}
        public DateTime DropTime{get;set;} 
        public DateTime PickupTime{get;set;} 
        public DateTime EntryTime{get;set;}

    }
    public class land
    {
        public string flag { get; set; }
        public int Zno { get; set; }
        public string landmark { get; set; }
    }
    public class VehicleDist
    {
        public string insupddelflag { get; set; }
        public int Id { get; set; }
        public string VehicleModelId { get; set; }
        public int FromKm { get; set; }
        public int ToKm { get; set; }
        public decimal Pricing { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
}
    public class HourBase
    {
        public string insupddelflag { get; set; }
        public int Id { get; set; }
        public int VehicleModelId { get; set; }
        //public string VehicleModel { get; set; }
        public string Hours { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public decimal Price { get; set; }

    }
    public class Pricing
    {
        public int SrNo { get; set; }
        public int Duration { get; set; }
        public int KiloMtr { get; set; }

        public int IndicaRate { get; set; }
        public int IndigoRate { get; set; }
        public int InnovaRate { get; set; }
        public int Tag { get; set; }
    }

    public class VehicleDistancePriceConfiguration
    {
        public int Id { get; set; }      
        public string SourceLoc {get; set;}
        public string DestinationLoc {get; set;}
        public float SourceLat {get; set;}
        public float SourceLng {get; set;}
        public float DestinationLat {get; set;}
        public float DestinationLng {get; set;}
        public string VehicleModelId {get; set;}
        public string VehicleTypeId {get; set;}
        public string PricingTypeId {get; set;}
        public float UnitPrice {get; set;}
        public int Distance { get; set; }
        public float Amount {get; set;}
        public string flag {get; set;}

    }
    public class start
    {
        public string flag { get; set; }
        public int SlNo { get; set; }
        public DateTime EntryDate { get; set; }
        public int VechID { get; set; }
        public string RegistrationNo { get; set; }
        public string DriverName { get; set; }
        public string PartyName { get; set; }
        public string PickupPlace { get; set; }

        public string DropPlace { get; set; }
        public int StartMeter { get; set; }
        public DateTime PickupTime { get; set; }
        public string ExecutiveName { get; set; }
        public decimal BookingNo { get; set; }
        public DateTime EntryTime { get; set; }
        public string CloseStatus { get; set; }
    }

    public class Vechlogin
    {
        public string flag { get; set; }
        public int Id { get; set; }
        public int CompanyId { get; set; }

        public int VechId { get; set; }
        public string RegNo { get; set; }
        public string DriverName { get; set; }
        public string LoginLandMark { get; set; }
        public string CurrentLandMark { get; set; }
        public string StartKiloMtr { get; set; }
        public string CurStatus { get; set; }
        public string DriverMobileNo { get; set; }
        public string ExecutiveName { get; set; }
        public string Remarks { get; set; }
        public int GenratedAmount { get; set; }
        public int NoofTimesLogin { get; set; }
        public int TotalGeneratedAmount { get; set; }
        public string VechType { get; set; }
        public int VehicleModelId { get; set; }
        public int ServiceTypeId { get; set; }
        public int VehicleGroupId { get; set; }

    }

    public class vechlogout
    {
        public string flag { get; set; }
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int VechId { get; set; }
        public string RegNo { get; set; }
        public string DriverName { get; set; }
        public string LoginLandMark { get; set; }
        public string CurrentLandMark { get; set; }
        public string EndMtr { get; set; }
        public string CurStatus { get; set; }
        public string DriverMobileNo { get; set; }
        public string ExecutiveName { get; set; }
        public string Remarks { get; set; }
        public int GenratedAmount { get; set; }
        public int NoofTimesLogin { get; set; }

        public int TotalGeneratedAmount { get; set; }

        public string VechType { get; set; }


    }
    public class Advertisment
    {
        public string flag { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
        public string AdvertisementTitle { get; set; }
        public string Description { get; set; }
        public string Clarification { get; set; }
        public string Conclusion { get; set; }
        public float Price { get; set; }
        public int AdvertisementTypeId { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public float AdvertisementAmount { get; set; }
        public string CompanyName { get; set; }
        public string Area { get; set; }
    }
    public class Appusers
    {
        public string flag { get; set; }

        public int id { get; set; }


        public string Username { get; set; }

        public string Email { get; set; }

        public string Mobilenumber { get; set; }

        public string Password { get; set; }

        public string Mobileotp { get; set; }

        public string Emailotp { get; set; }

        public string Passwordotp { get; set; }

        public int Status { get; set; }

        public string Createdon { get; set; }

        public string Mobileotpsenton { get; set; }

        public string Emailotpsenton { get; set; }

        public string noofattempts { get; set; }
        public decimal Amount { get; set; }
        public string AccountNo { get; set; }

        
    }
    public class products
    {
        public string flag { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
        public string ProductName{ get; set; }
        public float Price { get; set; }
        public string DescriptionOne { get; set; }
        public string DescriptionTwo { get; set; }
        public string DescriptionThree { get; set; }
        public string DescriptionFour { get; set; }
        public DateTime? ProductUploadeDate { get; set; }
        public DateTime? ProductExpiredDate { get; set; }
        
    }
    public class Carousel
    {
        public string flag { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
        public string ImageName { get; set; }
        public string ImageCaption { get; set; }
        public string ImageDesc { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public string ImgPath { get; set; }

    }

    public class VehicleDocuments
    {

        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int createdById { get; set; }
        public int UpdatedById { get; set; }
        public int docTypeId { get; set; }
        public string docType { get; set; }
        public string FileName { get; set; }
        public int IsExpired { get; set; }
        public string FileContent { get; set; }
        public DateTime? expiryDate { get; set; }
        public DateTime? dueDate { get; set; }
        public string insupddelflag { get; set; }
        public string DocumentNo { get; set; }
        public string DocumentNo2 { get; set; }
        public int isVerified { get; set; }

    }

    public class DriverDocuments
    {

        public int Id { get; set; }
        public int DriverId { get; set; }
        public int createdById { get; set; }
        public int UpdatedById { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
     
        public int docTypeId { get; set; }
        public string docType { get; set; }
        public string docName { get; set; }
        public int IsExpired { get; set; }
        public string docContent { get; set; }

        public DateTime? expiryDate { get; set; }
        public DateTime? dueDate { get; set; }
        public string insupddelflag { get; set; }
        public string DocumentNo { get; set; }
        public string DocumentNo2 { get; set; }
        public int isVerified { get; set; }
    }
    public class ewallet
    {
        public string flag { get; set; }
        public int Id { get; set; }
        public int transhistoryid { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }

        public string Status { get; set; }
        public string Comment { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public int TransrefId { get; set; }
        public string MobileNo { get; set; }
        public string AccountNo { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }

        public object Details { get; set; }

        public string TransactionId { get; set; }

        public string TransactionMode { get; set; }
    }
    public class PricingCredentials
    {
        public string flag { get; set; }

        public int Id { get; set; }

        public string PriceCode { get; set; }

        public int PriceType { get; set; }

        public int UnitPrice { get; set; }

        public int VehicleGroup { get; set; }

        public int VehicleModel { get; set; }

        public int PackageType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int VehicleType { get; set; }
    }
    public class ChargesDiscounts
    {
        public string Type;
        public string Value;

        public int Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public int cdType { get; set; }
        public int Category { get; set; }

        public int ApplyAs { get; set; }
        public int cdValue { get; set; }
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Flag { get; set; }
    }
    public class MandUserDocs
    {


        public string flag { get; set; }

        public int Id { get; set; }

        public int DocTypeId { get; set; }

        public int Countryid { get; set; }

        public int UserTypeId { get; set; }
    }
    
    public class MandVehicleDocs
    {

        public string flag { get; set; }

        public int Id { get; set; }

        public int Countryid { get; set; }

        public int VehicleGroupId { get; set; }

        public int DocTypeId { get; set; }
    }

}

