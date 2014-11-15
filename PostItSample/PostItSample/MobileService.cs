using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostItSample {
    class MobileService {

        //モバイルサービスへの接続のためのキー
        const string ApplicationUrl = "https://xxxxxxx.azure-mobile.net/";
        const string ApplicationKey = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
        readonly MobileServiceClient _client = new MobileServiceClient(ApplicationUrl, ApplicationKey);


        public List<PostItItem> Items { get; private set; }

        public MobileService() {
            Items = new List<PostItItem>();
        }

        //挿入
        public async Task Insert(PostItItem item) {
            try {
                await _client.GetTable<PostItItem>().InsertAsync(item);
                Items.Insert(0,item);

            } catch (MobileServiceInvalidOperationException e) {
                //ERROR
            }
        }
        //削除
        public async Task Delete(PostItItem item){
            item.DeleteFlg = true;
            await _client.GetTable<PostItItem>().UpdateAsync(item);
            Items.Remove(item);
        }

        //初期化 max=最大取得数
        public async Task<List<PostItItem>> Init(int max) {
            Items = await _client.GetTable<PostItItem>().OrderByDescending(x => x.CreateAt).Where(x=>x.DeleteFlg==false).Take(max).ToListAsync();
            return Items;
        }
    }
}
