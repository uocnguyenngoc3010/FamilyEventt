﻿namespace FamilyEventt.Dto
{
    public class ErrorViewModelDto
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
