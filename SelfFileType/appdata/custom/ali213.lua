function Description()
    return
        '单机游戏_单机游戏下载_单机游戏门户_游侠网';
end

function ExtensionName() return '.ali213'; end

function Icon() return 'ali213.ico'; end

function Urls() return {'ali213.net'}; end

function FileName(url)
    local name = "游侠网";
    -- url = url .. "/";
    local start = string.find( url, "/zt/");
    if start ~= nil then
        name = string.match(url, "/zt/(.-)/");
        name = name .. '.zt';
    end
    start = string.find( url, "/pcgame/" );
    if start ~= nil then
        name = string.match(url, "/pcgame/(.-).html");
        name = name .. '.pcgame';
    end
    return name;
end


local url_zt = 'https://www.ali213.net/zt/farlonesails/';
local url_pcgame = 'https://down.ali213.net/pcgame/lostinplay.html';
print(FileName(url_zt))
print(FileName(url_pcgame))

