function Description()
    return
        'Nexus Mods is the largest modding site and community on the internet. ';
end

function ExtensionName() return '.nexusmods'; end

function Icon() return 'nexusmods.ico'; end

function Urls() return {'nexusmods.com'}; end

function FileName(url)
    local name = "Nexus Mods";
    name = url:gsub("https://nexusmods.com/", "");
    name = url:gsub("https://www.nexusmods.com/", "");
    name = name:gsub("/", ".");
    name = name:gsub("?", "#");
    return name;
end




function FileName2(url)
    local defaultHost = "nexusmods.com";
    local defaultName = "Nexus Mods";
    local name = defaultName;
    url = string.gsub(url, "https://", "");
    url = string.gsub(url, "http://", "");
    url = url .. "/";
    url = string.gsub(url, "//", "/");

    local start = '';
    start = string.find( url, "/v/" );
    if start ~= nil then
        name = string.match(url, "/v/(.+)");
        name = urlDecode(name);
        name = 'v.' .. name;
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

function urlDecode(s)  
    s = string.gsub(s, '%%(%x%x)', function(h) return string.char(tonumber(h, 16)) end)  
    return s  
end  


-- local url1 = 'https://www.nexusmods.com/';
-- local url2 = 'https://www.nexusmods.com/residentevil32020/mods/883';
-- print(FileName2(url1))
-- print(FileName2(url2))

