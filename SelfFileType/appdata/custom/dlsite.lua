function Description()
    return
        '下载同人志・同人游戏・同人音声・ASMR，就在「DLsite 同人 - R18」';
end

function ExtensionName() return '.dlsite'; end

function Icon() return 'dlsite.ico'; end

function Urls() return {'dlsite.com'}; end

function FileName(url)
    local defaultHost = "dlsite.com";
    local defaultName = "DLsite";
    local name = defaultName;
    url = string.gsub(url, "https://", "");
    url = string.gsub(url, "http://", "");
    url = url .. "/";
    url = string.gsub(url, "//", "/");

    local start = '';
    start = string.find( url, "/product_id/" );
    if start ~= nil then
        name = string.match(url, "/product_id/(.+)%.html");
        name = name .. '.product';
        name = string.gsub(name, "/.", ".");
    end
    start = string.find( url, "/maker_id/" );
    if start ~= nil then
        name = string.match(url, "/maker_id/(.+)%.html");
        name = urlDecode(name);
        name = name .. '.maker';
        name = string.gsub(name, "/.", ".");
    end
    start = string.find( url, "/title_id/" );
    if start ~= nil then
        name = string.match(url, "/title_id/(.-)/");
        name = urlDecode(name);
        name = name .. '.maker';
        name = string.gsub(name, "/.", ".");
    end
    start = string.find( url, "/keyword_creater/" );
    if start ~= nil then
        name = string.match(url, "/keyword_creater/(.-)/");
        name = urlDecode(name);
        name = name .. '.creater';
        name = string.gsub(name, "/.", ".");
    end
    start = string.find( url, "/genre/" );
    if start ~= nil then
        name = string.match(url, "/genre/(.-)/");
        name = urlDecode(name);
        name = name .. '.genre';
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


-- local url1 = 'https://www.dlsite.com/maniax/work/=/product_id/RJ359297.html';
-- local url2 = 'https://www.dlsite.com/maniax/circle/profile/=/maker_id/RG09366.html';
-- local url3 = 'https://www.dlsite.com/maniax/fsr/=/title_id/SRI0000025946/order/title_d/from/work.titles';
-- local url4 = 'https://www.dlsite.com/maniax/fsr/=/keyword_creater/%22%E3%81%A8%E3%81%91%E3%83%BC%E3%81%86%E3%81%95%E3%81%8E%22';
-- local url5 = 'https://www.dlsite.com/maniax/fsr/=/genre/504/from/work.genre';
-- print(FileName(url1))
-- print(FileName(url2))
-- print(FileName(url3))
-- print(FileName(url4))
-- print(FileName(url5))
-- print(urlDecode(url2))
