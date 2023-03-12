function Description()
    return
        'Nyaa是一个侧重于东亚（中国、日本及韩国）多媒体资源的BT站点。它也是世界上最大的动漫专用种子索引站。';
end

function ExtensionName() return '.nyaa'; end

function Icon() return 'nyaa.ico'; end

function Urls() return {'nyaa.si'}; end

function FileName(url)
    local name = "Nyaa";
    url = url .. "/";
    local start = string.find( url, "/view/");
    if start ~= nil then
        name = string.match(url, "/view/(.-)/");
        name = name .. '.view';
    end
    start = string.find( url, "/user/" );
    if start ~= nil then
        name = string.match(url, "/user/(.-)/");
        name = name .. '.user';
    end
    return name;
end


local url_view = 'https://sukebei.nyaa.si/view/3187178';
print(FileName(url_view))
