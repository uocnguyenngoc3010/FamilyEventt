using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyEventt.Services
{
    public class ScriptService : IScript
    {
        protected readonly FamilyEventContext context;
        public ScriptService(FamilyEventContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteScript(string id)
        {
            try
            {
                var script = await this.context.Script.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (script != null)
                {
                    script.Status = false;
                    this.context.Script.Update(script);
                    this.context.SaveChanges();
                    await this.context.ChatMessage.LoadAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Script>> GetAll()
        {
            try
            {
                var data = await this.context.Script.Where(x=>x.Status).ToListAsync();
                if(data != null)
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<Script> GetScriptById(string ID)
        {
            try
            {
                var script = await this.context.Script
                    .Where(x => x.Id == ID && x.Status)
                    .Select(x => new Script()
                    {
                        Id = x.Id,
                        ScriptName= x.ScriptName,
                        Status = x.Status,
                        ScriptContent = x.ScriptContent,
                    })
                    .FirstOrDefaultAsync();
                if(script == null)
                {
                    return null;
                }
                else
                {
                    return script;
                }
            }catch(Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<List<Script>> GetScriptByName(string name)
        {
            try
            {
                var script = await this.context.Script.Where(x => x.ScriptName.Contains(name) && x.Status).ToListAsync();
                if (script == null)
                {
                    return null;
                }
                else
                {
                    return script;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> InsertScript(ScriptDto script)
        {
            try
            {
                var scpt= new Script();
                scpt.Id = "SId" + Guid.NewGuid().ToString().Substring(0, 20);
                scpt.Status = script.Status;
                scpt.ScriptName = script.ScriptName;
                scpt.ScriptContent = script.ScriptContent;

                await this.context.Script.AddAsync(scpt);
                this.context.SaveChanges();
                await this.context.Event.LoadAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateScript(ScriptDto script)
        {
            try
            {
                var scpt = await this.context.Script.Where(x => x.Status && x.Id.Equals(script.Id)).FirstOrDefaultAsync();
                if(scpt == null) { return false; }
                else
                {
                    scpt.Status = script.Status;
                    scpt.ScriptName = script.ScriptName;
                    scpt.ScriptContent = script.ScriptContent;

                    this.context.Script.Update(scpt);
                    this.context.SaveChanges();
                    await this.context.Event.LoadAsync();
                    return true;
                }
 
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
