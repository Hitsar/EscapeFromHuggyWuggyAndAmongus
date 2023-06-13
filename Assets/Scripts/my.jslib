mergeInto(LibraryManager.library, {

	SaveExtern : function(date) {
    	var dateString = UTF8ToString(date);
    	var myobj = JSON.parse(dateString);
    	player.setData(myobj);
  	},

  	LoadExtern : function(){
    	player.getData().then(_date => {
        	const myJSON = JSON.stringify(_date);
        	myGameInstance.SendMessage('YandexSDK', 'SetPlayerInfo', myJSON);
    	});
 	},

 	SetToLeaderboard : function(value){
    	ysdk.getLeaderboards()
      	.then(lb => {
        lb.setLeaderboardScore('Top', value);
      });
  	},

    ShowAdExtern : function(){
        myGameInstance.SendMessage('YandexSDK', 'MuteAudio');
        ysdk.adv.showFullscreenAdv({
            callbacks: 
            {
                onClose: function(wasShown) {
                    myGameInstance.SendMessage('YandexSDK', 'PlayAudio');
                },
                onError: function(error) {
                }
            }
        })
    },

    RewardedAdExtern : function(){
        ysdk.adv.showRewardedVideo({
            callbacks: 
            {
                onOpen: () => {
                },
                onRewarded: () => {
                    myGameInstance.SendMessage('DiedMenu', 'OnRewarded');
                },
                onClose: () => {
                }, 
                onError: (e) => {
                }
            }
        })
    },
});