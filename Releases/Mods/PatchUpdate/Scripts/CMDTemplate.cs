using System;
using System.Collections.Generic;


public class TemplateCMD : ConsoleCmdAbstract
{
    private EntityPlayer _entityPlayer;
    public override string[] GetCommands() => new[] {"KTemplate"};

    public override string GetDescription() =>
        "Template Console Command";

    public override void Execute(List<string> _params, CommandSenderInfo _senderInfo)
    {
        _entityPlayer = GameManager.Instance.World.GetPrimaryPlayer();
        {
            GameManager.Instance.ChatMessageServer(_cInfo: null,
                _chatType: EChatType.Global, _senderEntityId: _entityPlayer.entityId,
                _msg: "Template Message", _mainName: _entityPlayer.EntityName,
                _localizeMain: false, _recipientEntityIds: null);
        }
    }
}