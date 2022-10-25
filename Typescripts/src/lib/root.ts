import { bind, component, OnInit } from "zes-unity-jslib";
import { getLogger } from "zes-unity-jslib/dist/lib/logger";

@component()
export class Root implements OnInit {

    @bind("#label")
    label!: CS.TMPro.TMP_Text;

    async zesOnInit() {
        logger.debug(`root start`);
    }
}

const logger = getLogger(Root.name);

