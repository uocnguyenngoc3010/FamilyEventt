using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class VoucherService : IVoucher
    {
        protected readonly FamilyEventContext context;

        public VoucherService(FamilyEventContext context)
        {
            this.context = context;
        }

        public async Task<Voucher> Insert(VoucherDto newVoucher)
        {
            try
            {
                var voucher = new Voucher();
                voucher.StartDate= DateTime.Now;
                voucher.EndDate= newVoucher.EndDate;
                voucher.VoucherDiscount= newVoucher.VoucherDiscount;
                voucher.VoucherName= newVoucher.VoucherName;
                voucher.VoucherImage= newVoucher.VoucherImage;
                voucher.Status = true;
                voucher.VoucherId= "VcID"+Guid.NewGuid().ToString().Substring(0,20);

                await this.context.Voucher.AddAsync(voucher);
                await this.context.SaveChangesAsync();

                return voucher;
            }catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Voucher> Update(VoucherDto newVoucher)
        {
            try
            {
                var check = await this.context.Voucher.Where(x => x.VoucherId.Equals(newVoucher.VoucherId)).FirstOrDefaultAsync();
                if (check != null)
                {
                    var voucher = new Voucher();
                    //voucher.StartDate = DateTime.Now;
                    voucher.EndDate = newVoucher.EndDate;
                    voucher.VoucherDiscount = newVoucher.VoucherDiscount;
                    voucher.VoucherName = newVoucher.VoucherName;
                    voucher.VoucherImage = newVoucher.VoucherImage;
                    voucher.Status = newVoucher.Status;
                    //voucher.VoucherId = "VcID" + Guid.NewGuid().ToString().Substring(0, 20);

                    context.Voucher.Update(voucher);
                    await this.context.SaveChangesAsync();
                    return voucher;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<Voucher>> GetAllVoucher()
        {

            try
            {
                var data = await this.context.Voucher
                    .Where(x => x.Status == true)
                    .OrderBy(x => x.VoucherName)
                    .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public async Task<List<Voucher>> SearchByName(string name)
        {
            try
            {
                var data = await this.context.Voucher
                    .Where(x => x.Status && x.VoucherName.Contains(name))
                    .ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<Voucher> SearchByID(string ID)
        {
            try
            {
                var data = await this.context.Voucher
                    .Where(x => x.Status && x.VoucherId.Equals(ID))
                    .FirstOrDefaultAsync();
                if(data == null)
                    return null;
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<bool> Disable()
        {
            try
            {
                var data= await this.context.Voucher.ToListAsync();
                foreach (var voucher in data)
                {
                    if (voucher.EndDate < DateTime.Now)
                    {
                        voucher.Status= false;
                    }
                    context.Voucher.Update(voucher);
                    await this.context.SaveChangesAsync();
                }
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var check = await this.context.Voucher.Where(x=>x.VoucherId.Equals(id)).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.Status=false;
                    context.Voucher.Update(check);
                    await this.context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<Event> AddVoucher(string eventid, string voucherid)
        {
            try
            {
                var ev = await this.context.Event.Where(x=>x.EventId.Equals(eventid) && x.Status).FirstOrDefaultAsync();
                var vc = await this.context.Voucher.Where(x=>x.VoucherId.Equals(voucherid) && x.Status).FirstOrDefaultAsync();
                var check = await this.context.Voucher.ToListAsync();
                foreach(var x in check)
                {
                    if (x.EventId.Equals(ev.EventId))
                    {
                        throw new Exception("event add only 1 voucher");
                        return ev;
                    }
                }
                if (ev != null)
                {
                    if (vc != null)
                    {
                        vc.EventId = ev.EventId;
                        ev.TotalPrice= ev.TotalPrice-(ev.TotalPrice*(vc.VoucherDiscount/100));
                        vc.Status = false;
                    }
                }
                this.context.Event.Update(ev);
                this.context.Voucher.Update(vc);
                await this.context.SaveChangesAsync();

                return ev;
            }
            catch (Exception ex) {
                return null;
            }
        }
    }
}
