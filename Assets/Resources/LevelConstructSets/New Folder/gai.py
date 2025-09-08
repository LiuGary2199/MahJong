import os
import yaml
import re

def main():
    # 获取脚本所在目录（即要处理的目录）
    script_dir = os.path.dirname(os.path.abspath(__file__))
    
    print(f"正在处理目录: {script_dir}")
    
    # 定义要修改的 guid 值
    asset_script_guid = "219e85b8783287b4b943be4f7460c1ea"
    meta_guid = "3ce9787e232a64e4f9781071c1a1d7ba"
    
    # 统计修改的文件数量
    asset_modified_count = 0
    meta_modified_count = 0
    error_count = 0

    # 遍历当前目录下的所有文件
    for file in os.listdir(script_dir):
        file_path = os.path.join(script_dir, file)
        
        # 跳过目录和脚本自身
        if os.path.isdir(file_path) or file == os.path.basename(__file__):
            continue
            
        # 处理 .asset 文件
        if file.endswith(".asset"):
            try:
                # 读取文件内容
                with open(file_path, 'r', encoding='utf-8') as f:
                    content = f.read()
                
                # 查找 m_Script 的 guid 模式
                # 匹配 m_Script 下的 guid 字段
                pattern = r'(m_Script:\s*\{[^}]*guid:\s*)([a-f0-9]{32})([^}]*\})'
                match = re.search(pattern, content, re.MULTILINE | re.DOTALL)
                
                if match:
                    old_guid = match.group(2)
                    # 替换 GUID
                    new_content = re.sub(pattern, r'\g<1>' + asset_script_guid + r'\g<3>', content, flags=re.MULTILINE | re.DOTALL)
                    
                    # 写回文件
                    with open(file_path, 'w', encoding='utf-8') as f:
                        f.write(new_content)
                    
                    print(f"已修改 .asset 文件: {file}")
                    print(f"  旧 GUID: {old_guid}")
                    print(f"  新 GUID: {asset_script_guid}")
                    asset_modified_count += 1
                else:
                    print(f"跳过 .asset 文件 {file}：未找到 m_Script.guid 字段")
            except Exception as e:
                print(f"处理 .asset 文件 {file} 时出错: {e}")
                error_count += 1
        
        # 处理 .meta 文件
        elif file.endswith(".meta"):
            try:
                with open(file_path, 'r', encoding='utf-8') as f:
                    data = yaml.safe_load(f)
                
                # 检查是否存在 guid 并修改
                if isinstance(data, dict) and "guid" in data:
                    old_guid = data["guid"]
                    data["guid"] = meta_guid
                    with open(file_path, 'w', encoding='utf-8') as f:
                        yaml.dump(data, f, sort_keys=False, allow_unicode=True)
                    print(f"已修改 .meta 文件: {file}")
                    print(f"  旧 GUID: {old_guid}")
                    print(f"  新 GUID: {meta_guid}")
                    meta_modified_count += 1
                else:
                    print(f"跳过 .meta 文件 {file}：未找到 guid 字段")
            except Exception as e:
                print(f"处理 .meta 文件 {file} 时出错: {e}")
                error_count += 1

    # 输出处理结果统计
    print("\n" + "="*50)
    print("处理完成！")
    print(f"成功修改的 .asset 文件数量: {asset_modified_count}")
    print(f"成功修改的 .meta 文件数量: {meta_modified_count}")
    if error_count > 0:
        print(f"处理出错的文件数量: {error_count}")
    print("="*50)

if __name__ == "__main__":
    main()
