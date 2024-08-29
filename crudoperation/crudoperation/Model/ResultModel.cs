namespace crudoperation.Model
{
    public class ResultModel<T>
    {
        public bool Success { get; set; }

        public int MsgCode { get; set; }

        public string Message { get; set; }

        public T Model { get; set; }

        public List<T> LstModel { get; set; }

        public string Token { get; set; }

        public int TotalRecords { get; set; }

        public string MsgType { get; set; }

        public bool Status { get; set; }

        public string ProfileImage { get; set; }

        public string Email { get; set; }

        public ResultModel()
        {
            Success = true;
            Message = "Success";
            MsgCode = 1;
        }
    }
}

