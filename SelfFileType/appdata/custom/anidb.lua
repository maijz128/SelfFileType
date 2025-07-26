function Description()
    return
        'AniDB 是免费向公众开放的非营利性动漫信息数据库。';
end

function ExtensionName() return '.anidb'; end

function Icon() return 'anidb.ico'; end

function Urls() return {'anidb.net'}; end

function FileName(url)
    local defaultHost = "anidb.net";
    local defaultName = "AniDB";
    local name = defaultName;
    url = string.gsub(url, "https://", "");
    url = string.gsub(url, "http://", "");
    url = url .. "/";
    url = string.gsub(url, "//", "/");

    local start = '';
    start = string.find( url, "/anime/" );
    if start ~= nil then
        name = string.match(url, "/anime/(.+)");
        name = name .. '.anime';
        name = string.gsub(name, "/.", ".");
    end
    start = string.find( url, "/tag/" );
    if start ~= nil then
        name = string.match(url, "/tag/(.+)");
        name = name .. '.tag';
        name = string.gsub(name, "/.", ".");
    end
    start = string.find( url, "/collection/" );
    if start ~= nil then
        name = string.match(url, "/collection/(.+)");
        name = name .. '.collection';
        name = string.gsub(name, "/.", ".");
    end
    start = string.find( url, "/character/" );
    if start ~= nil then
        name = string.match(url, "/character/(.+)");
        name = name .. '.character';
        name = string.gsub(name, "/.", ".");
    end
    start = string.find( url, "/creator/" );
    if start ~= nil then
        name = string.match(url, "/creator/(.+)");
        name = name .. '.creator';
        name = string.gsub(name, "/.", ".");
    end

    if name == defaultName then
        name = url;
        name = string.gsub(name, "www." .. defaultHost .. "/", "");
        name = string.gsub(name, defaultHost .. "/", "");
        name = string.gsub(name .. "/", "//", "");
        name = string.gsub(name, "/", ".");
    end

    return name;
end


local url_anime = 'https://anidb.net/anime/8730';
print(FileName(url_anime))

