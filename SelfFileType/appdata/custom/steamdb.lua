function Description()
    return
        'SteamDB is database of everything on Steam.';
end

function ExtensionName() return '.steamdb'; end

function Icon() return 'steamdb.ico'; end

function Urls() return {'steamdb.info'}; end

function FileName2(url)
    local defaultHost = "steamdb.info";
    local defaultName = "SteamDB";
    local name = "SteamDB";
    url = string.gsub(url, "https://", "");
    url = string.gsub(url, "http://", "");
    url = url .. "/";
    url = string.gsub(url, "//", "/");
    if name == defaultName then
        name = string.gsub(name, "www." .. defaultHost .. "/", "");
        name = string.gsub(name, defaultHost .. "/", "");
        name = string.gsub(name .. "/", "//", "");
        name = string.gsub(name, "/", ".");
        name = name:gsub("?", "#");
    end
    return name;
end




function FileName(url)
    local defaultHost = "steamdb.info";
    local defaultName = "SteamDB";
    local name = defaultName;
    url = string.gsub(url, "https://", "");
    url = string.gsub(url, "http://", "");
    url = url .. "/";
    url = string.gsub(url, "//", "/");

    local start = '';
    -- start = string.find( url, "/app/" );
    -- if start ~= nil then
    --     name = string.match(url, "/app/(.+)/");
    --     -- name = urlDecode(name);
    --     name = 'app.' .. name;
    --     name = string.gsub(name, "/.", ".");
    -- end


    if name == defaultName then
        name = url;
        name = string.gsub(name, "www." .. defaultHost .. "/", "");
        name = string.gsub(name, defaultHost .. "/", "");
        name = string.gsub(name .. "/", "//", "");
        name = string.gsub(name, "/", ".");
    end

    return name;
end

function urlDecode(s)  
    s = string.gsub(s, '%%(%x%x)', function(h) return string.char(tonumber(h, 16)) end)  
    return s  
end  


-- local url1 = 'https://www.steamdb.info/';
-- local url2 = 'https://steamdb.info/app/3654030/info/';
-- print(FileName(url1))
-- print(FileName(url2))

