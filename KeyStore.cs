#define AddKeys
using System;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NFCKeyApp {
    public sealed record KeyData {
        public string Name;
        public string Key;
    }
    public class KeyStore: IStore<KeyData> {

        public static KeyStore Instance { get; } = new KeyStore();

        private KeyStore() : base(Path.GetFullPath("keys.json", FileSystem.Current.AppDataDirectory)) {}

        protected override void Load() {
            base.Load();
#if DEBUG && AddKeys
            if (!Store.ContainsKey("side_door_1")) {
                Store["key_r-check-ok"] = new() {
                    Key = "/dev/null",
                    Name = "Success"
                };
            }
            Store["front_door_1"] = new() {
                Key = "bmlvdm5yOTgzMDg5Mm4tMzM5NG5pMG9tZHNtdmlyMDRuM20wIG4wLWk0OWkgd2VuIDs=",
                Name = "Front Door"
            };
            Store["side_door_1"] = new() {
                Key = "Zm1vaWZtb2l3bXBuaXAwWzAtMm1bbUFTSU4zMDlKTS0gSTMwLVFXTSAtKCZ0XjI4QjdOOSZOWzs=",
                Name = "Side Door 1"
            };
            Store["back_door_1"] = new() {
                Key = "bmlvdm5yOTgzMDg5Mm4tMzM5NG5pMG9tZHNtdmlyMDRuM20wIG4wLWk0OWkgd2VuIDs=",
                Name = "Back Door"
            };
            OnStoreEdited();
#endif
        }
    }

}
