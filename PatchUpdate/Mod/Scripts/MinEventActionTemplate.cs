using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;


public class MinEventActionTemplate : MinEventActionBase
{
    EntityPlayer _entityPlayer;

    string command;
    //ClientInfo _cInfo;


    public override void Execute(MinEventParams _params)
    {
        _entityPlayer = GameManager.Instance.World.GetPrimaryPlayer();

        if (command == null)
        {
            return;
        }
        else
        {
            if (!SingletonMonoBehaviour<ConnectionManager>.Instance.IsClient)
            {
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.ChatMessageServer(_cInfo: null,
                        _chatType: EChatType.Global, _senderEntityId: _entityPlayer.entityId,
                        _msg: "Template Message", _mainName: _entityPlayer.EntityName,
                        _localizeMain: false, _recipientEntityIds: null);
                }
            }
            else
            {
                SingletonMonoBehaviour<ConnectionManager>.Instance.SendToServer(
                    NetPackageManager.GetPackage<NetPackageConsoleCmdServer>()
                        .Setup(GameManager.Instance.World.GetPrimaryPlayerId(), command), false);
            }
        }
    }

    public override bool ParseXmlAttribute(XmlAttribute _attribute)
    {
        bool xmlAttribute = base.ParseXmlAttribute(_attribute);
        if (xmlAttribute || !(_attribute.Name == "command"))
        {
            return xmlAttribute;
        }

        this.command = _attribute.Value;
        return true;
    }
}